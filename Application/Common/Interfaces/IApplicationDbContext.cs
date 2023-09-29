using Wbc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using OptimaJet.Workflow.Core.Persistence;

namespace Wbc.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        IWorkflowProvider Provider { get; }
        DbSet<Resource> Resources { get; set; }
        DbSet<TopResource> TopResources { get; set; }
        DbSet<ResourceArea> ResourceAreas { get; set; }
        DbSet<Domain.Entities.Permission> Permissions { get; set; }
        DbSet<LongRunningRequestTemp> LongRunningRequestTemps { get; set; }
        DbSet<UserPermission> UserPermissions { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Subscriber> Subscribers { get; set; }
        DbSet<UserSubscription> UserSubscriptions { get; set; }
        DbSet<Process> Processes { get; set; }
        DbSet<RequiredDocument> RequiredDocuments { get; set; }
        DbSet<ProcessRequiredDocument> ProcessRequiredDocuments { get; set; }
        DbSet<ProcessSubmittedDocument> ProcessSubmittedDocuments { get; set; }
        DbSet<SubscriberProcessWorkflow> SubscriberProcessWorkflows { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<DocumentTransitionHistory> DocumentTransitionHistories { get; set; }
        DbSet<WorkflowScheme> WorkflowSchemes { get; set; }
        DbSet<WorkflowInbox> WorkflowInboxes { get; set; }
        DbSet<OrganisationApprovalRole> OrganisationApprovalRoles { get; set; }
        DbSet<OrganisationUserApprovalRole> OrganisationUserApprovalRoles { get; set; }
        DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        DbSet<VehicleMake> VehicleMakes { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<ExchangeRate> ExchangeRates { get; set; }
        DbSet<VehicleCategory> VehicleCategories { get; set; }
        DbSet<VehicleType> VehicleTypes { get; set; }
        DbSet<FreightOverage> FreightOverages { get; set; }
        DbSet<FreightRate> FreightRates { get; set; }
        DbSet<ClassifyHscode> ClassifyHscodes { get; set; }
        DbSet<CalculatedDuty> CalculatedDuties { get; set; }
        DbSet<VehicleFactory> VehicleFactories { get; set; }       

        DbSet<VehicleSpecialFeature> VehicleSpecialFeatures { get; set; }
        DbSet<VehicleSearchPool> VehicleSearchPools { get; set; }
        DbSet<HSCodePool> HSCodePools { get; set; }
        DbSet<HSCodeTariffTax> hSCodeTariffTaxes { get; set; }
        DbSet<Tariff> tariffs { get; set; }
        DbSet<UserHSCodePool> UserHSCodePools { get; set; }
        DbSet<UserTariff> UserTariffs { get; set; }
        DbSet<UserTariffExtraTax> UserTariffExtraTaxes { get; set; }
        DbSet<TariffBenchmark> TariffBenchmarks { get; set; }
        DbSet<DocumentType> DocumentTypes { get; set; }
        DbSet<DocumentCategory> DocumentCategories { get; set; }
        DbSet<Agency> Agencies { get; set; }
        DbSet<AgencyDocument> AgencyDocuments { get; set; }
        DbSet<AgencyHsCode> AgencyHsCodes { get; set; }
        DbSet<HSCodeDocument> HSCodeDocuments { get; set; }
        DbSet<ExtraDocumentValue> ExtraDocumentValues { get; set; }
        DbSet<Section> Sections { get; set; }   
        DbSet<Segment> Segments { get; set; }
        DbSet<Sector> Sectors { get; set; }
        DbSet<HSCodeRecord> HSCodeRecords { get; set; }
        DbSet<GuestUser> GuestUsers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
