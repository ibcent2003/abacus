using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            //Seed, if necessary

            if (!context.TopResources.Any())
            {
                var resources = new TopResource
                {
                    ResourceName = "Settings",
                    LocalizationKey = "SettingsTopMenuRes",
                    IsActive = true,
                    Order = 1,
                    CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                    Created = DateTime.Now,
                    LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                    LastModified = DateTime.Now,
                    ResourceAreas = new List<ResourceArea>
                                                                {
                                                                    new ResourceArea
                                                                        {
                                                                            AreaName = "MenuResource",
                                                                            LocalizationKey = "MenuAreaRes",
                                                                            IconUrl = "far fa-fw fa-list-alt",
                                                                            IsActive = true,
                                                                            Order = 1,
                                                                            CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                            Created = DateTime.Now,
                                                                            LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                            LastModified = DateTime.Now,
                                                                            Resources = new List<Resource>
                                                                                            {
                                                                                                new Resource
                                                                                                    {
                                                                                                        ResourcePage = "AddTopResource",
                                                                                                        LocalLizationKey = "AddTopResourceRes",
                                                                                                        IsActive = true,
                                                                                                        Order = 2,
                                                                                                        CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        Created = DateTime.Now,
                                                                                                        LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        LastModified = DateTime.Now,
                                                                                                        Permission = new Permission
                                                                                                                         {
                                                                                                                             PermissionName = "AddTopResource",
                                                                                                                             RequireAdminRole = true,
                                                                                                                             PersmissionDescription = "Add Top Resource",
                                                                                                                             LocalizationKey = "AddTopResourceRes",
                                                                                                                             CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             Created = DateTime.Now,
                                                                                                                             IsActive = true,
                                                                                                                             LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             LastModified = DateTime.Now,
                                                                                                                             Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                                                                                         }
                                                                                                    },
                                                                                                new Resource
                                                                                                    {
                                                                                                        ResourcePage = "ListTopResource",
                                                                                                        LocalLizationKey = "ListTopResourcesRes",
                                                                                                        IsActive = true,
                                                                                                        Order = 1,
                                                                                                        CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        Created = DateTime.Now,
                                                                                                        LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        LastModified = DateTime.Now,
                                                                                                        Permission = new Permission
                                                                                                                         {
                                                                                                                             PermissionName = "ListTopResource",
                                                                                                                             RequireAdminRole = true,
                                                                                                                             PersmissionDescription = "List Top Resource",
                                                                                                                             LocalizationKey = "ListTopResourceRes",
                                                                                                                             IsActive = true,
                                                                                                                             CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             Created = DateTime.Now,
                                                                                                                             LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             LastModified = DateTime.Now,
                                                                                                                             Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                                                                                         }
                                                                                                    },
                                                                                                new Resource
                                                                                                    {
                                                                                                        ResourcePage = "AddResource",
                                                                                                        LocalLizationKey = "AddResourceRes",
                                                                                                        IsActive = true,
                                                                                                        Order = 6,
                                                                                                        CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        Created = DateTime.Now,
                                                                                                        LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        LastModified = DateTime.Now,
                                                                                                        Permission = new Permission
                                                                                                                         {
                                                                                                                             PermissionName = "AddResource",
                                                                                                                             RequireAdminRole = true,
                                                                                                                             PersmissionDescription = "Add Resource",
                                                                                                                             LocalizationKey = "AddResourceRes",
                                                                                                                             IsActive = true,
                                                                                                                             CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             Created = DateTime.Now,
                                                                                                                             LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             LastModified = DateTime.Now,
                                                                                                                             Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                                                                                         }
                                                                                                    },
                                                                                                new Resource
                                                                                                    {
                                                                                                        ResourcePage = "ListResource",
                                                                                                        LocalLizationKey = "ListResourcesRes",
                                                                                                        IsActive = true,
                                                                                                        Order = 5,
                                                                                                        CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        Created = DateTime.Now,
                                                                                                        LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        LastModified = DateTime.Now,
                                                                                                        Permission = new Permission
                                                                                                                         {
                                                                                                                             PermissionName = "ListResource",
                                                                                                                             RequireAdminRole = true,
                                                                                                                             PersmissionDescription = "List Resource",
                                                                                                                             LocalizationKey = "ListResourceRes",
                                                                                                                             IsActive = true,
                                                                                                                             CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             Created = DateTime.Now,
                                                                                                                             LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             LastModified = DateTime.Now,
                                                                                                                             Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                                                                                         }
                                                                                                    },
                                                                                                new Resource
                                                                                                    {
                                                                                                        ResourcePage = "ListResourceArea",
                                                                                                        LocalLizationKey = "ListResourceAreasRes",
                                                                                                        IsActive = true,
                                                                                                        Order = 3,
                                                                                                        CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        Created = DateTime.Now,
                                                                                                        LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        LastModified = DateTime.Now,
                                                                                                        Permission = new Permission
                                                                                                                         {
                                                                                                                             PermissionName = "ListResourceArea",
                                                                                                                             RequireAdminRole = true,
                                                                                                                             PersmissionDescription = "List Resource Area",
                                                                                                                             LocalizationKey = "ListResourceAreaRes",
                                                                                                                             IsActive = true,
                                                                                                                             CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             Created = DateTime.Now,
                                                                                                                             LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             LastModified = DateTime.Now,
                                                                                                                             Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                                                                                         }
                                                                                                    },
                                                                                                new Resource
                                                                                                    {
                                                                                                        ResourcePage = "AddResourceArea",
                                                                                                        LocalLizationKey = "AddResourceAreaRes",
                                                                                                        IsActive = true,
                                                                                                        Order = 4,
                                                                                                        CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        Created = DateTime.Now,
                                                                                                        LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        LastModified = DateTime.Now,
                                                                                                        Permission = new Permission
                                                                                                                         {
                                                                                                                             PermissionName = "AddResourceArea",
                                                                                                                             RequireAdminRole = true,
                                                                                                                             PersmissionDescription = "Add Resource Area",
                                                                                                                             LocalizationKey = "AddResourceAreaRes",
                                                                                                                             CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             Created = DateTime.Now,
                                                                                                                             LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             LastModified = DateTime.Now,
                                                                                                                             Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                                                                                         }
                                                                                                    }
                                                                                            }
                                                                        },
                                                                    new ResourceArea
                                                                        {
                                                                            AreaName = "Permission",
                                                                            LocalizationKey = "UserPermissionRes",
                                                                            IconUrl = "fas fa-fw fa-user-cog",
                                                                            IsActive = true,
                                                                            Order = 2,
                                                                            CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                            Created = DateTime.Now,
                                                                            LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                            LastModified = DateTime.Now,
                                                                            Resources = new List<Resource>
                                                                                            {
                                                                                                new Resource
                                                                                                    {
                                                                                                        ResourcePage = "AddPermission",
                                                                                                        LocalLizationKey = "AddPermissionRes",
                                                                                                        IsActive = true,
                                                                                                        Order = 1,
                                                                                                        CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        Created = DateTime.Now,
                                                                                                        LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        LastModified = DateTime.Now,
                                                                                                        Permission = new Permission
                                                                                                                         {
                                                                                                                             PermissionName = "AddPermission",
                                                                                                                             RequireAdminRole = true,
                                                                                                                             PersmissionDescription = "Add Permission",
                                                                                                                             LocalizationKey = "AddPermissionRes",
                                                                                                                             IsActive = true,
                                                                                                                             CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             Created = DateTime.Now,
                                                                                                                             LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             LastModified = DateTime.Now,
                                                                                                                             Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                                                                                         }
                                                                                                    },
                                                                                                new Resource
                                                                                                    {
                                                                                                        ResourcePage = "ListPermission",
                                                                                                        LocalLizationKey = "ListPermissionRes",
                                                                                                        IsActive = true,
                                                                                                        Order = 2,
                                                                                                        CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        Created = DateTime.Now,
                                                                                                        LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                        LastModified = DateTime.Now,
                                                                                                        Permission = new Permission
                                                                                                                         {
                                                                                                                             PermissionName = "ListPermission",
                                                                                                                             RequireAdminRole = true,
                                                                                                                             PersmissionDescription = "List Permission",
                                                                                                                             LocalizationKey = "ListPermissionRes",
                                                                                                                             IsActive = true,
                                                                                                                             CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             Created = DateTime.Now,
                                                                                                                             LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                                                                                             LastModified = DateTime.Now,
                                                                                                                             Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                                                                                         }
                                                                                                    }
                                                                                            }
                                                                        }
                                                                }
                };


                var permissions = new List<Permission>
                                          {
                                              new Permission
                                                  {
                                                      PermissionName = "UpdateTopResource",
                                                      RequireAdminRole = true,
                                                      PersmissionDescription = "Update Top Resource",
                                                      LocalizationKey = "UpdateTopResourceRes",
                                                      IsActive = true,
                                                      CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      Created = DateTime.Now,
                                                      LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      LastModified = DateTime.Now,
                                                      Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                  },
                                              new Permission
                                                  {
                                                      PermissionName = "DeleteTopResource",
                                                      RequireAdminRole = true,
                                                      PersmissionDescription = "Delete Top Resource",
                                                      LocalizationKey = "DeleteResourceRes",
                                                      IsActive = true,
                                                      CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      Created = DateTime.Now,
                                                      LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      LastModified = DateTime.Now,
                                                      Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                  },
                                              new Permission
                                                  {
                                                      PermissionName = "UpdateResource",
                                                      RequireAdminRole = true,
                                                      PersmissionDescription = "Update Resource",
                                                      LocalizationKey = "UpdateResourceRes",
                                                      IsActive = true,
                                                      CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      Created = DateTime.Now,
                                                      LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      LastModified = DateTime.Now,
                                                      Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                  },
                                              new Permission
                                                  {
                                                      PermissionName = "DeleteResource",
                                                      RequireAdminRole = true,
                                                      PersmissionDescription = "Delete Resource",
                                                      LocalizationKey = "DeleteResourceRes",
                                                      IsActive = true,
                                                      CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      Created = DateTime.Now,
                                                      LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      LastModified = DateTime.Now,
                                                      Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                  },
                                              new Permission
                                                  {
                                                      PermissionName = "UpdateResourceArea",
                                                      RequireAdminRole = true,
                                                      PersmissionDescription = "Update Resource Area",
                                                      LocalizationKey = "UpdateResourceAreaRes",
                                                      IsActive = true,
                                                      CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      Created = DateTime.Now,
                                                      LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      LastModified = DateTime.Now,
                                                      Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                  },
                                              new Permission
                                                  {
                                                      PermissionName = "DeleteResourceArea",
                                                      RequireAdminRole = true,
                                                      PersmissionDescription = "Delete Resource Area",
                                                      LocalizationKey = "DeleteResourceAreaRes",
                                                      IsActive = true,
                                                      CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      Created = DateTime.Now,
                                                      LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      LastModified = DateTime.Now,
                                                      Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                  },
                                              new Permission
                                                  {
                                                      PermissionName = "UpdatePermission",
                                                      RequireAdminRole = true,
                                                      PersmissionDescription = "Update Permission",
                                                      LocalizationKey = "UpdatePermissionRes",
                                                      IsActive = true,
                                                      CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      Created = DateTime.Now,
                                                      LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      LastModified = DateTime.Now,
                                                      Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                  },
                                              new Permission
                                                  {
                                                      PermissionName = "DeletePermission",
                                                      RequireAdminRole = true,
                                                      PersmissionDescription = "Delete Permission",
                                                      LocalizationKey = "DeletePermissionRes",
                                                      IsActive = true,
                                                      CreatedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      Created = DateTime.Now,
                                                      LastModifiedBy = "23a6f518-b126-4561-8f5b-e35709e64bc9",
                                                      LastModified = DateTime.Now,
                                                      Users = new List<UserPermission> {new UserPermission {UserId = "23a6f518-b126-4561-8f5b-e35709e64bc9"}}
                                                  }
                                          };
                context.TopResources.Add(resources);
                context.Permissions.AddRange(permissions);
                await context.SaveChangesAsync();
            }
        }
    }
}