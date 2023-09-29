using Wbc.Application.Common.Attributes;

namespace Wbc.Application.Common.Enums
{
    public enum Policies
    {
        [PolicyClaimValues("CanUpdateTopResource", Roles.eTradeToolAdmin, Permission.UpdateTopResource)]
        CanUpdateTopResource,
        [PolicyClaimValues("CanDeleteTopResource", Roles.eTradeToolAdmin, Permission.DeleteTopResource)]
        CanDeleteTopResource,
        [PolicyClaimValues("CanAddTopResource", Roles.eTradeToolAdmin, Permission.AddTopResource)]
        CanAddTopResource,
        [PolicyClaimValues("CanListTopResource", Roles.eTradeToolAdmin, new[] { Permission.UpdateTopResource, Permission.DeleteTopResource, Permission.AddTopResource, Permission.ListTopResource })]
        CanListTopResource,
        [PolicyClaimValues("CanAddResource", Roles.eTradeToolAdmin, Permission.AddResource)]
        CanAddResource,
        [PolicyClaimValues("CanUpdateResource", Roles.eTradeToolAdmin, Permission.UpdateResource)]
        CanUpdateResource,
        [PolicyClaimValues("CanDeleteResource", Roles.eTradeToolAdmin, Permission.DeleteResource)]
        CanDeleteResource,
        [PolicyClaimValues("CanListResource", Roles.eTradeToolAdmin, new[] { Permission.AddResource, Permission.UpdateResource, Permission.DeleteResource, Permission.ListResource })]
        CanListResource,
        [PolicyClaimValues("CanListResourceArea", Roles.eTradeToolAdmin, new[] { Permission.UpdateResourceArea, Permission.DeleteResourceArea, Permission.AddResourceArea, Permission.ListResourceArea })]
        CanListResourceArea,
        [PolicyClaimValues("CanAddResourceArea", Roles.eTradeToolAdmin, Permission.AddResourceArea)]
        CanAddResourceArea,
        [PolicyClaimValues("CanUpdateResourceArea", Roles.eTradeToolAdmin, Permission.UpdateResourceArea)]
        CanUpdateResourceArea,
        [PolicyClaimValues("CanDeleteResourceArea", Roles.eTradeToolAdmin, Permission.DeleteResourceArea)]
        CanDeleteResourceArea,
        [PolicyClaimValues("CanAddPermission", Roles.eTradeToolAdmin, Permission.AddPermission)]
        CanAddPermission,
        [PolicyClaimValues("CanUpdatePermission", Roles.eTradeToolAdmin, Permission.UpdatePermission)]
        CanUpdatePermission,
        [PolicyClaimValues("CanDeletePermission", Roles.eTradeToolAdmin, Permission.DeletePermission)]
        CanDeletePermission,
        [PolicyClaimValues("CanListPermission", Roles.eTradeToolAdmin, new[] { Permission.AddPermission, Permission.UpdatePermission, Permission.DeletePermission, Permission.ListPermission })]
        CanListPermission,
        [PolicyClaimValues("CanAddRequiredDocument", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.AddRequiredDocument)]
        CanAddRequiredDocument,
        [PolicyClaimValues("CanUpdateRequiredDocument", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.UpdateRequiredDocument)]
        CanUpdateRequiredDocument,
        [PolicyClaimValues("CanDeleteRequiredDocument", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.DeleteRequiredDocument)]
        CanDeleteRequiredDocument,
        [PolicyClaimValues("CanListRequiredDocument", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, new[] { Permission.AddRequiredDocument, Permission.UpdateRequiredDocument, Permission.DeleteRequiredDocument, Permission.ListRequiredDocument })]
        CanListRequiredDocument,
        [PolicyClaimValues("CanAddProcess", Roles.eTradeToolAdmin, Permission.AddProcess)]
        CanAddProcess,
        [PolicyClaimValues("CanUpdateProcess", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.UpdateProcess)]
        CanUpdateProcess,
        [PolicyClaimValues("CanDeleteProcess", Roles.eTradeToolAdmin, Permission.DeleteProcess)]
        CanDeleteProcess,
        [PolicyClaimValues("CanListProcess", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, new[] { Permission.AddProcess, Permission.UpdateProcess, Permission.DeleteRequiredDocument, Permission.ListRequiredDocument })]
        CanListProcess,
        [PolicyClaimValues("CanAddProcessRequiredDocument", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.AddProcessRequiredDocument)]
        CanAddProcessRequiredDocument,
        [PolicyClaimValues("CanUpdateProcessRequiredDocument", Roles.eTradeToolAdmin, Permission.UpdateProcessRequiredDocument)]
        CanUpdateProcessRequiredDocument,
        [PolicyClaimValues("CanDeleteProcessRequiredDocument", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.DeleteProcessRequiredDocument)]
        CanDeleteProcessRequiredDocument,
        [PolicyClaimValues("CanListProcessRequiredDocument", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, new[] { Permission.AddProcessRequiredDocument, Permission.UpdateProcessRequiredDocument, Permission.DeleteProcessRequiredDocument, Permission.ListProcessRequiredDocument })]
        CanListProcessRequiredDocument,
        [PolicyClaimValues("CanApproveChamberRegistration", Roles.eTradeToolAdmin, Permission.ApproveChamberRegistration)]
        CanApproveChamberRegistration,
        [PolicyClaimValues("CanListChamberRegistration", Roles.eTradeToolAdmin, new[] { Permission.ListChamberRegistration, Permission.ApproveChamberRegistration })]
        CanListChamberRegistration,
        [PolicyClaimValues("CanListOrganisationalUsers", Roles.CubeClientAdmin, new[] { Permission.ListOrganisationalUsers, Permission.ViewOrganisationalUserDetails, Permission.AddOrganisationalUser })]
        CanListOrganisationalUsers,
        [PolicyClaimValues("CanViewOrganisationalUserDetails", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.ViewOrganisationalUserDetails)]
        CanViewOrganisationalUserDetails,
        [PolicyClaimValues("CanAddOrganisationalUser", Roles.CubeClientAdmin, Permission.AddOrganisationalUser)]
        CanAddOrganisationalUser,
        [PolicyClaimValues("CanAddWorkflowScheme", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.AddWorkflowScheme)]
        CanAddWorkflowScheme,
        [PolicyClaimValues("CanListApprovalInbox", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.ListApprovalInbox)]
        CanListApprovalInbox,
        [PolicyClaimValues("CanAddOrganisationApprovalRole", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.AddOrganisationApprovalRole)]
        CanAddOrganisationApprovalRole,
        [PolicyClaimValues("CanListOrganisationApprovalRole", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, new[] { Permission.AddOrganisationApprovalRole, Permission.UpdateOrganisationApprovalRole, Permission.DeleteOrganisationApprovalRole, Permission.ListOrganisationApprovalRole })]
        CanListOrganisationApprovalRole,
        [PolicyClaimValues("CanUpdateOrganisationApprovalRole", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.UpdateOrganisationApprovalRole)]
        CanUpdateOrganisationApprovalRole,
        [PolicyClaimValues("CanDeleteOrganisationApprovalRole", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.DeleteOrganisationApprovalRole)]
        CanDeleteOrganisationApprovalRole,
        [PolicyClaimValues("CanAssignUserPermissions", new[] { Roles.eTradeToolAdmin, Roles.CubeClientAdmin, Roles.CubeClientUser }, Permission.AssignPermission)]
        CanAssignUserPermissions,


        ////MINE/////
        [PolicyClaimValues("CanAddVehicleMake", Roles.eTradeToolAdmin, Permission.AddVehicleMake)]
        CanAddVehicleMake,

        [PolicyClaimValues("CanUpdateVehicleMake", Roles.eTradeToolAdmin, Permission.UpdateVehicleMake)]
        CanUpdateVehicleMake,

        [PolicyClaimValues("CanDeleteVehicleMake", Roles.eTradeToolAdmin, Permission.DeleteVehicleMake)]
        CanDeleteVehicleMake,

        [PolicyClaimValues("CanListVehicleMake", Roles.eTradeToolAdmin, new[] { Permission.UpdateVehicleMake, Permission.DeleteVehicleMake, Permission.AddVehicleMake, Permission.ListVehicleMake })]
        CanListVehicleMake,

        //Vehicle model

        [PolicyClaimValues("CanAddVehicleModel", Roles.eTradeToolAdmin, Permission.AddVehicleMakeModel)]
        CanAddVehicleModel,

        [PolicyClaimValues("CanUpdateVehicleModel", Roles.eTradeToolAdmin, Permission.UpdateVehicleModel)]
        CanUpdateVehicleModel,

        [PolicyClaimValues("CanDeleteVehicleModel", Roles.eTradeToolAdmin, Permission.DeleteVehicleModel)]
        CanDeleteVehicleModel,

        [PolicyClaimValues("CanListVehicleModel", Roles.eTradeToolAdmin, Permission.ListVehicleModel)]
        CanListVehiclModel,




        [PolicyClaimValues("CanAddSubscriptionType", Roles.eTradeToolAdmin, Permission.AddSubscriptionType)]
        CanAddSubscriptionType,


        [PolicyClaimValues("CanUpdateSubscriptionType", Roles.eTradeToolAdmin, Permission.UpdateSubscriptionType)]
        CanUpdateSubscriptionType,

        [PolicyClaimValues("CanDeleteSubscriptionType", Roles.eTradeToolAdmin, Permission.DeleteSubscriptionType)]
        CanDeleteSubscriptionType,

        [PolicyClaimValues("CanListSubscriptionType", Roles.eTradeToolAdmin, new[] { Permission.UpdateSubscriptionType, Permission.DeleteSubscriptionType, Permission.AddSubscriptionType, Permission.ListSubscriptionType })]
        CanListSubscriptionType,


        /// <summary>
        /// /started here
        /// </summary>
        [PolicyClaimValues("CanAddCountry", Roles.eTradeToolAdmin, Permission.AddCountry)]
        CanAddCountry,
        [PolicyClaimValues("CanUpdateCountry", Roles.eTradeToolAdmin, Permission.UpdateCountry)]
        CanUpdateCountry,
        [PolicyClaimValues("CanDeleteCountry", Roles.eTradeToolAdmin, Permission.DeleteCountry)]
        CanDeleteCountry,
        [PolicyClaimValues("CanListCountry", Roles.eTradeToolAdmin, new[] { Permission.UpdateCountry, Permission.DeleteCountry, Permission.AddCountry, Permission.ListCountry })]
        CanListCountry,

        [PolicyClaimValues("CanAddSubscriptionPlan", Roles.eTradeToolAdmin, Permission.AddSubscriptionPlan)]
        CanAddSubscriptionPlan,
        [PolicyClaimValues("CanUpdateSubscriptionPlan", Roles.eTradeToolAdmin, Permission.UpdateSubscriptionPlan)]
        CanUpdateSubscriptionPlan,
        [PolicyClaimValues("CanDeleteSubscriptionPlan", Roles.eTradeToolAdmin, Permission.DeleteSubscriptionPlan)]
        CanDeleteSubscriptionPlan,
        [PolicyClaimValues("CanListSubscriptionPlan", Roles.eTradeToolAdmin, new[] { Permission.UpdateSubscriptionPlan, Permission.DeleteSubscriptionPlan, Permission.AddSubscriptionPlan, Permission.ListSubscriptionPlan })]
        CanListSubscriptionPlan,

        [PolicyClaimValues("CanCreateSearchByMake", Roles.eTradeToolAdmin, Permission.CreateSearchByMake)]
        CanCreateSearchByMake,
        [PolicyClaimValues("CanViewDutyApprovalList", Roles.eTradeToolAdmin, Permission.ViewDutyApprovalList)]
        CanViewDutyApprovalList,

        [PolicyClaimValues("CanAddDocumentCategory", Roles.eTradeToolAdmin, Permission.AddDocumentCategory)]
        CanAddDocumentCategory,
        [PolicyClaimValues("CanUpdateDocumentCategory", Roles.eTradeToolAdmin, Permission.UpdateDocumentCategory)]
        CanUpdateDocumentCategory,
        [PolicyClaimValues("CanDeleteDocumentCategory", Roles.eTradeToolAdmin, Permission.DeleteDocumentCategory)]
        CanDeleteDocumentCategory,
        [PolicyClaimValues("CanListDocumentCategory", Roles.eTradeToolAdmin, new[] { Permission.AddDocumentCategory, Permission.UpdateDocumentCategory, Permission.DeleteDocumentCategory, Permission.ListDocumentCategory })]
        CanListDocumentCategory,

        [PolicyClaimValues("CanAddDocumentType", Roles.eTradeToolAdmin, Permission.AddDocumentType)]
        CanAddDocumentType,
        [PolicyClaimValues("CanListDocumentType", Roles.eTradeToolAdmin, new[] { Permission.AddDocumentType, Permission.UpdateDocumentType, Permission.DeleteDocumentType, Permission.ListDocumentType })]
        CanListDocumentType,
        [PolicyClaimValues("CanUpdateDocumentType", Roles.eTradeToolAdmin, Permission.UpdateDocumentType)]
        CanUpdateDocumentType,
        [PolicyClaimValues("CanDeleteDocumentType", Roles.eTradeToolAdmin, Permission.DeleteDocumentType)]
        CanDeleteDocumentType,
        [PolicyClaimValues("CanAddAgency", Roles.eTradeToolAdmin, Permission.AddAgency)]
        CanAddAgency,
        [PolicyClaimValues("CanListDocumentType", Roles.eTradeToolAdmin, new[] { Permission.AddAgency, Permission.UpdateAgency, Permission.DeleteAgency, Permission.ListAgency })]
        CanListAgency,
        [PolicyClaimValues("CanUpdateAgency", Roles.eTradeToolAdmin, Permission.UpdateAgency)]
        CanUpdateAgency,
        [PolicyClaimValues("CanDeleteAgency", Roles.eTradeToolAdmin, Permission.DeleteAgency)]
        CanDeleteAgency,
        [PolicyClaimValues("CanAddHSCode", Roles.eTradeToolAdmin, Permission.AddHSCode)]
        CanAddHSCode,
        [PolicyClaimValues("CanListHSCode", Roles.eTradeToolAdmin, new[] { Permission.AddHSCode, Permission.UpdateHSCode, Permission.DeleteHSCode, Permission.ListHSCode })]
        CanListHSCode,
        [PolicyClaimValues("CanUpdateHSCode", Roles.eTradeToolAdmin, Permission.UpdateHSCode)]
        CanUpdateHSCode,
        [PolicyClaimValues("CanDeleteHSCode", Roles.eTradeToolAdmin, Permission.DeleteHSCode)]
        CanDeleteHSCode,


    }
}
