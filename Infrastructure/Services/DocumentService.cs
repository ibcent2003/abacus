using System;
using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IApplicationDbContext _dbContext;
        public DocumentService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void DeleteEmptyPreHistory(Guid processId)
        {
            var existingNotUsedItems = _dbContext.DocumentTransitionHistories.Where(x => x.ProcessId == processId && !x.TransitionTime.HasValue);

            _dbContext.DocumentTransitionHistories.RemoveRange(existingNotUsedItems);

            var result = _dbContext.SaveChangesAsync(CancellationToken.None).Result;
        }

        public void ChangeState(Guid id, string nextState, string nextStateName)
        {
            var document = GetDocument(id);

            if (document == null) return;

            document.State = nextState;

            document.StateName = nextStateName;

            var result = _dbContext.SaveChangesAsync(CancellationToken.None).Result;
        }

        private Document GetDocument(Guid id, bool loadChildEntities = true)
        {
            Document document = null;

            if (!loadChildEntities)
            {
                document = _dbContext.Documents.Find(id);
            }
            else
            {
                document = _dbContext.Documents
                    .Include(x => x.DocumentTransitionHistories).FirstOrDefault(x => x.WorkflowProcessId == id);
            }

            return document;

        }

    }
}
