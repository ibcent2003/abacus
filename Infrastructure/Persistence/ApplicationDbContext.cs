using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.DbPersistence;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Common;
using Wbc.Domain.Entities;
using Wbc.Infrastructure.Services;
using WorkflowInbox = Wbc.Domain.Entities.WorkflowInbox;
using WorkflowScheme = Wbc.Domain.Entities.WorkflowScheme;

namespace Wbc.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        private IDbContextTransaction _currentTransaction;

        public ApplicationDbContext(DbContextOptions options, ICurrentUserService currentUserService, IDateTime dateTime, IConfiguration config) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
            Provider = new MSSQLProvider(config.GetConnectionString("DefaultConnection"));
        }

        public IWorkflowProvider Provider { get; private set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<LongRunningRequestTemp> LongRunningRequestTemps { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<TopResource> TopResources { get; set; }
        public DbSet<ResourceArea> ResourceAreas { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<RequiredDocument> RequiredDocuments { get; set; }
        public DbSet<ProcessRequiredDocument> ProcessRequiredDocuments { get; set; }
        public DbSet<ProcessSubmittedDocument> ProcessSubmittedDocuments { get; set; }
        public DbSet<SubscriberProcessWorkflow> SubscriberProcessWorkflows { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentTransitionHistory> DocumentTransitionHistories { get; set; }
        public DbSet<WorkflowScheme> WorkflowSchemes { get; set; }
        public DbSet<WorkflowInbox> WorkflowInboxes { get; set; }
        public DbSet<OrganisationApprovalRole> OrganisationApprovalRoles { get; set; }
        public DbSet<OrganisationUserApprovalRole> OrganisationUserApprovalRoles { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Country> Countries { get; set; }
       public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
       public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<VehicleCategory> VehicleCategories { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<FreightOverage> FreightOverages { get; set; }
        public DbSet<FreightRate> FreightRates { get; set; }
        public DbSet<ClassifyHscode> ClassifyHscodes { get; set; }
        public DbSet<CalculatedDuty> CalculatedDuties { get; set; }
        public DbSet<VehicleFactory> VehicleFactories { get; set; }     
        public DbSet<VehicleSpecialFeature> VehicleSpecialFeatures { get; set; }
        public DbSet<VehicleSearchPool> VehicleSearchPools{ get; set;}
        public DbSet<HSCodePool> HSCodePools { get; set; }
        public DbSet<HSCodeTariffTax> hSCodeTariffTaxes { get; set; }
        public DbSet<Tariff> tariffs { get; set; }
        public DbSet<UserHSCodePool> UserHSCodePools { get; set; }
        public DbSet<UserTariff> UserTariffs { get; set; }
        public DbSet<UserTariffExtraTax> UserTariffExtraTaxes { get; set; }
        public DbSet<TariffBenchmark> TariffBenchmarks { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentCategory> DocumentCategories { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<AgencyHsCode> AgencyHsCodes { get; set; }
        public DbSet<AgencyDocument> AgencyDocuments { get; set; }
        public DbSet<HSCodeDocument> HSCodeDocuments { get; set; }
        public DbSet<ExtraDocumentValue> ExtraDocumentValues { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Segment> Segments{get; set;}
        public DbSet<HSCodeRecord> HSCodeRecords { get; set; }
        public DbSet<GuestUser> GuestUsers { get; set; }



        public DbSet<Sector> Sectors { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var userId = _currentUserService.GetUserId();

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    if (string.IsNullOrEmpty(entry.Entity.CreatedBy))
                    {
                        entry.Entity.CreatedBy = userId;
                    }

                    entry.Entity.Created = _dateTime.Now;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    if (string.IsNullOrEmpty(entry.Entity.LastModifiedBy))
                    {
                        entry.Entity.LastModifiedBy = userId;
                    }

                    entry.Entity.LastModified = _dateTime.Now;
                }
            }

            foreach (var entry in ChangeTracker.Entries<HasWorkflowApprovalProcess>())
            {

                if (entry.State == EntityState.Added)
                {
                    var workflowProcessId = Guid.NewGuid();

                    var currentUser = string.IsNullOrEmpty(userId) ? workflowProcessId.ToString() : userId;

                    entry.Entity.Document = new Document()
                    {
                        AuthorId = currentUser,
                        ProcessName = entry.Entity.ProcessName,
                        DocumentSource = entry.Entity.DocumentSource,
                        SubmittedOn = _dateTime.Now,
                        SubmittedBy = currentUser,
                        WorkflowProcessId = workflowProcessId,
                        StateName = "initial",
                        State = "initial"
                    };

                    var saved = base.SaveChangesAsync(cancellationToken);

                    Task.Run(() => WorkflowInit.Runtime.CreateInstanceAsync(entry.Entity.WorkflowSchemeCode, workflowProcessId, cancellationToken).ContinueWith((t) =>
                                                                                                                                                                {
                                                                                                                                                                    var commands = WorkflowInit.Runtime.GetAvailableCommands(workflowProcessId, currentUser);
                                                                                                                                                                    var command = commands.FirstOrDefault();
                                                                                                                                                                    if (command == null) return;
                                                                                                                                                                    WorkflowInit.Runtime.ExecuteCommand(command, currentUser, currentUser);

                                                                                                                                                                }, cancellationToken),
                    cancellationToken);


                    return saved;
                }



            }

            return base.SaveChangesAsync(cancellationToken);
        }


        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null) return;

            _currentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);
                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}