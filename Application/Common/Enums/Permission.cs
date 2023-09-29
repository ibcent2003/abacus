using Wbc.Application.Common.Attributes;

namespace Wbc.Application.Common.Enums
{
    public enum Permission
    {
        [StringValue("AddTopResource")]
        AddTopResource,
        [StringValue("UpdateTopResource")]
        UpdateTopResource,
        [StringValue("DeleteTopResource")]
        DeleteTopResource,
        [StringValue("ListTopResource")]
        ListTopResource,
        [StringValue("AddResource")]
        AddResource,
        [StringValue("UpdateResource")]
        UpdateResource,
        [StringValue("DeleteResource")]
        DeleteResource,
        [StringValue("ListResource")]
        ListResource,
        [StringValue("ListResourceArea")]
        ListResourceArea,
        [StringValue("AddResourceArea")]
        AddResourceArea,
        [StringValue("UpdateResourceArea")]
        UpdateResourceArea,
        [StringValue("DeleteResourceArea")]
        DeleteResourceArea,
        [StringValue("AddPermission")]
        AddPermission,
        [StringValue("UpdatePermission")]
        UpdatePermission,
        [StringValue("DeletePermission")]
        DeletePermission,
        [StringValue("ListPermission")]
        ListPermission,
        [StringValue("AssignPermission")]
        AssignPermission,
        [StringValue("AddRequiredDocument")]
        AddRequiredDocument,
        [StringValue("UpdateRequiredDocument")]
        UpdateRequiredDocument,
        [StringValue("DeleteRequiredDocument")]
        DeleteRequiredDocument,
        [StringValue("ListRequiredDocument")]
        ListRequiredDocument,
        [StringValue("AddProcess")]
        AddProcess,
        [StringValue("UpdateProcess")]
        UpdateProcess,
        [StringValue("DeleteProcess")]
        DeleteProcess,
        [StringValue("ListProcess")]
        ListProcess,
        [StringValue("AddProcessRequiredDocument")]
        AddProcessRequiredDocument,
        [StringValue("UpdateProcessRequiredDocument")]
        UpdateProcessRequiredDocument,
        [StringValue("DeleteProcessRequiredDocument")]
        DeleteProcessRequiredDocument,
        [StringValue("ListProcessRequiredDocument")]
        ListProcessRequiredDocument,
        [StringValue("ListChamberRegistration")]
        ListChamberRegistration,
        [StringValue("ApproveChamberRegistration")]
        ApproveChamberRegistration,
        [StringValue("ListOrganisationalUsers")]
        ListOrganisationalUsers,
        [StringValue("ViewOrganisationalUserDetails")]
        ViewOrganisationalUserDetails,
        [StringValue("AddOrganisationalUser")]
        AddOrganisationalUser,
        [StringValue("AddWorkflowScheme")]
        AddWorkflowScheme,
        [StringValue("ListApprovalInbox")]
        ListApprovalInbox,
        [StringValue("AddOrganisationApprovalRole")]
        AddOrganisationApprovalRole,
        [StringValue("ListOrganisationApprovalRole")]
        ListOrganisationApprovalRole,
        [StringValue("UpdateOrganisationApprovalRole")]
        UpdateOrganisationApprovalRole,
        [StringValue("ListOrganisationApprovalRole")]
        DeleteOrganisationApprovalRole,


        [StringValue("AddVehicleMake")]
        AddVehicleMake,

        [StringValue("UpdateVehicleMake")]
        UpdateVehicleMake,

        [StringValue("DeleteVehicleMake")]
        DeleteVehicleMake,

        [StringValue("ListVehicleMake")]
        ListVehicleMake,

        //Vehcile model

        [StringValue("AddVehicleModel")]
        AddVehicleMakeModel,

        [StringValue("UpdateVehicleModel")]
        UpdateVehicleModel,

        [StringValue("DeleteVehicleModel")]
        DeleteVehicleModel,

        [StringValue("ListVehicleModel")]
        ListVehicleModel,

        [StringValue("AddSubscriptionType")]
        AddSubscriptionType,

        [StringValue("UpdateSubscriptionType")]
        UpdateSubscriptionType,

        [StringValue("DeleteSubscriptionType")]
        DeleteSubscriptionType,

        [StringValue("ListSubscriptionType")]
        ListSubscriptionType,

        [StringValue("AddCountry")]
        AddCountry,

        [StringValue("UpdateCountry")]
        UpdateCountry,

        [StringValue("DeleteCountry")]
        DeleteCountry,

        [StringValue("ListCountry")]
        ListCountry,

        [StringValue("AddSubscriptionPlan")]
        AddSubscriptionPlan,

        [StringValue("UpdateSubscriptionPlan")]
        UpdateSubscriptionPlan,

        [StringValue("DeleteSubscriptionPlan")]
        DeleteSubscriptionPlan,

        [StringValue("ListSubscriptionPlan")]
        ListSubscriptionPlan,

        [StringValue("CreateSearchByMake")]
        CreateSearchByMake,

        [StringValue("ViewDutyApprovalList")]
        ViewDutyApprovalList,

        [StringValue("AddDocumentCategory")]
        AddDocumentCategory,

        [StringValue("UpdateDocumentCategory")]
        UpdateDocumentCategory,

        [StringValue("DeleteDocumentCategory")]
        DeleteDocumentCategory,

        [StringValue("ListDocumentCategory")]
        ListDocumentCategory,
        [StringValue("AddDocumentType")]
        AddDocumentType,

        [StringValue("ListDocumentType")]
        ListDocumentType,

        [StringValue("UpdateDocumentType")]
        UpdateDocumentType,

        [StringValue("DeleteDocumentType")]
        DeleteDocumentType,

        [StringValue("AddAgency")]
        AddAgency,

        [StringValue("ListAgency")]
        ListAgency,

        [StringValue("UpdateAgency")]
        UpdateAgency,

        [StringValue("DeleteAgency")]
        DeleteAgency,

        [StringValue("AddHSCode")]
        AddHSCode,

        [StringValue("ListHSCode")]
        ListHSCode,

        [StringValue("UpdateHSCode")]
        UpdateHSCode,

        [StringValue("DeleteHSCode")]
        DeleteHSCode,

    }
}
