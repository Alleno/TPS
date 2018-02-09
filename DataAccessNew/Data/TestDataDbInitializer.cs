using System;
using System.Linq;
using TPS.Core.Models;

namespace DataAccessNew.Data
{
    public class TestDataDbInitializer
    {
        public static void Initialize(DataContextNew contextNew)
        {
            contextNew.Database.EnsureCreated();

            if (contextNew.Contracts.Any())
            {
                return;
            }

            contextNew.Employees.Clear();
            var employees = new[]
            {
                new Employee{BadgeId="1", EmployeeId="1", FirstName="Bob",LastName="Brow", EmployeeTypeId = contextNew.EmployeeTypes.Single(i => i.Name == "RA").Id },
                new Employee{BadgeId="1", EmployeeId="1", FirstName="Alice",LastName="Anderson", EmployeeTypeId = contextNew.EmployeeTypes.Single(i => i.Name == "RSM").Id },
                new Employee{BadgeId="1", EmployeeId="1", FirstName="Charlie",LastName="Chaplain", EmployeeTypeId = contextNew.EmployeeTypes.Single(i => i.Name == "MDA").Id },
                new Employee{BadgeId="1", EmployeeId="1", FirstName="Diana",LastName="Daily", EmployeeTypeId = contextNew.EmployeeTypes.Single(i => i.Name == "RA").Id },
                new Employee{BadgeId="1", EmployeeId="1", FirstName="Ethan",LastName="Evers", EmployeeTypeId = contextNew.EmployeeTypes.Single(i => i.Name == "RSM").Id },
                new Employee{BadgeId="1", EmployeeId="1", FirstName="Fiona",LastName="Finklestein", EmployeeTypeId = contextNew.EmployeeTypes.Single(i => i.Name == "Director").Id  },
                new Employee{BadgeId="1", EmployeeId="1", FirstName="Gail",LastName="Graham", EmployeeTypeId = contextNew.EmployeeTypes.Single(i => i.Name == "Deputy Director").Id },
                new Employee{BadgeId="1", EmployeeId="1", FirstName="Hubert",LastName="Hahn", EmployeeTypeId = contextNew.EmployeeTypes.Single(i => i.Name == "Admin").Id }
            };
            foreach (Employee e in employees)
            {
                contextNew.Employees.Add(e);
            }
            contextNew.SaveChanges();

            contextNew.Sponsors.Clear();
            var sponsors = new[]
            {
                new Sponsor{Name="Air Force"},
                new Sponsor{Name="Navy"},
                new Sponsor{Name="Army"},
                new Sponsor{Name="National Guard"},
                new Sponsor{Name="OSD"}
            };
            foreach (Sponsor s in sponsors)
            {
                contextNew.Sponsors.Add(s);
            }
            contextNew.SaveChanges();

            contextNew.Divisions.Clear();
            var divisions = new[]
            {
                new Division{Name="JAWD"},
                new Division{Name="CARD"},
                new Division{Name="SFRD"}
            };
            foreach (Division d in divisions)
            {
                contextNew.Divisions.Add(d);
            }
            contextNew.SaveChanges();

            contextNew.TaskOrders.Clear();
            var taskOrders = new[]
            {
                new TaskOrder
                {
                    Title = "Bomb the Russians with Napalm",
                    Abstract = "Strategy for defeating Putin",
                    Objective = "Something",
                    FundingAmount = (decimal)1000000.99,
                    FundingCategoryId = contextNew.FundingCategories.Single(i => i.Name == "Funding from Services").Id,
                    SponsorId = sponsors.Single(i => i.Name=="Air Force").Id,
                    DateSignedBySponsor = Convert.ToDateTime("01/02/2017"),
                    ApprovalStatusId = contextNew.ApprovalStatuses.Single(i => i.Name == "Approved").Id,
                    AnticipatedAudienceId = contextNew.AnticipatedAudiences.Single(i => i.Name == "The Public").Id,
                    VisibilityLevelId = contextNew.VisibilityLevels.Single(i => i.Name == "somewhat visible").Id,
                    DateApproval = Convert.ToDateTime("01/20/2017"),
                    DatePlacedOnContract = Convert.ToDateTime("02/01/2017"),
                    DateStart = Convert.ToDateTime("02/01/2017"),
                    DateEnd = Convert.ToDateTime("02/01/2018")
                },

                new TaskOrder
                {
                    Title = "Reform the Pentagon",
                    Abstract = "Stop spending so much money",
                    Objective = "Something",
                    FundingAmount = (decimal)300000.99,
                    FundingCategoryId = contextNew.FundingCategories.Single(i => i.Name == "Funding from OSD").Id,
                    SponsorId = sponsors.Single(i => i.Name=="OSD").Id,
                    DateSignedBySponsor = Convert.ToDateTime("03/04/2017"),
                    ApprovalStatusId = contextNew.ApprovalStatuses.Single(i => i.Name == "Pending Approval").Id,
                    AnticipatedAudienceId = contextNew.AnticipatedAudiences.Single(i => i.Name == "The Public").Id,
                    VisibilityLevelId = contextNew.VisibilityLevels.Single(i => i.Name == "somewhat visible").Id,
                    DateApproval = Convert.ToDateTime("06/20/2017"),
                    DatePlacedOnContract = Convert.ToDateTime("06/21/2017"),
                    DateStart = Convert.ToDateTime("07/01/2017"),
                    DateEnd = Convert.ToDateTime("03/01/2018")
                },

                new TaskOrder
                {
                    Title = "Iraq 2040",
                    Abstract = "Investigation into the effects of nation building",
                    Objective = "Something",
                    FundingAmount = (decimal)250000.99,
                    FundingCategoryId = contextNew.FundingCategories.Single(i => i.Name == "Funding from Services").Id,
                    SponsorId = sponsors.Single(i => i.Name=="National Guard").Id,
                    DateSignedBySponsor = Convert.ToDateTime("4/20/2017"),
                    ApprovalStatusId = contextNew.ApprovalStatuses.Single(i => i.Name == "Approved").Id,
                    AnticipatedAudienceId = contextNew.AnticipatedAudiences.Single(i => i.Name == "The Public").Id,
                    VisibilityLevelId = contextNew.VisibilityLevels.Single(i => i.Name == "somewhat visible").Id,
                    DateApproval = Convert.ToDateTime("4/20/2017"),
                    DatePlacedOnContract = Convert.ToDateTime("4/20/2017"),
                    DateStart = Convert.ToDateTime("04/21/2017"),
                    DateEnd = Convert.ToDateTime("04/21/2018")
                },

                new TaskOrder
                {
                    Title = "Ballistic Missile Defense",
                    Abstract = "Alternative fuels for rocket boosters",
                    Objective = "Something",
                    FundingAmount = (decimal)470000.99,
                    FundingCategoryId = contextNew.FundingCategories.Single(i => i.Name == "Funding from Services").Id,
                    SponsorId = sponsors.Single(i => i.Name=="Air Force").Id,
                    DateSignedBySponsor = Convert.ToDateTime("1/20/2017"),
                    ApprovalStatusId = contextNew.ApprovalStatuses.Single(i => i.Name == "Approved").Id,
                    AnticipatedAudienceId = contextNew.AnticipatedAudiences.Single(i => i.Name == "The Public").Id,
                    VisibilityLevelId = contextNew.VisibilityLevels.Single(i => i.Name == "somewhat visible").Id,
                    DateApproval = Convert.ToDateTime("1/2/2017"),
                    DatePlacedOnContract = Convert.ToDateTime("2/10/2017"),
                    DateStart = Convert.ToDateTime("02/10/2017"),
                    DateEnd = Convert.ToDateTime("10/21/2017")
                },
            };
            foreach (var t in taskOrders)
            {
                contextNew.TaskOrders.Add(t);
            }
            contextNew.SaveChanges();

            contextNew.Amendments.Clear();
            var amendments = new[]
            {
                new Amendment
                {
                    TaskOrderId = taskOrders.Single(i => i.Title == "Iraq 2040").Id,
                    Title = "Iraq 2050",
                    Abstract = "Follow on funding for Iraq 2040",
                    Objective = "Something",
                    FundingAmount = 100000,
                    AnticipatedAudienceId = contextNew.AnticipatedAudiences.Single(i => i.Name == "The Public").Id,
                    FundingCategoryId = contextNew.FundingCategories.Single(i => i.Name == "No Funding").Id,
                    VisibilityLevelId = contextNew.VisibilityLevels.Single(i => i.Name == "somewhat visible").Id,
                    DateSignedBySponsor = Convert.ToDateTime("4/20/2018"),
                    DateStart = Convert.ToDateTime("4/21/2018"),
                    DateEnd = Convert.ToDateTime("4/20/2019"),
                    ApprovalStatusId = contextNew.ApprovalStatuses.Single(i => i.Name == "Proposed").Id
                },

                new Amendment
                {
                    TaskOrderId = taskOrders.Single(i => i.Title == "Reform the Pentagon").Id,
                    Title = "No cost extension to reform the Pentagon",
                    Abstract = "We didn't finish, so had to ask for more time",
                    Objective = "Something",
                    FundingAmount = 0,
                    AnticipatedAudienceId = contextNew.AnticipatedAudiences.Single(i => i.Name == "The Public").Id,
                    VisibilityLevelId = contextNew.VisibilityLevels.Single(i => i.Name == "somewhat visible").Id,
                    FundingCategoryId = contextNew.FundingCategories.Single(i => i.Name == "No Funding").Id,
                    DateSignedBySponsor = Convert.ToDateTime("5/1/2017"),
                    DateStart = Convert.ToDateTime("3/2/2018"),
                    DateEnd = Convert.ToDateTime("10/21/2018"),
                    ApprovalStatusId = contextNew.ApprovalStatuses.Single(i => i.Name == "Approved").Id
                },

                new Amendment
                {
                    TaskOrderId = taskOrders.Single(i => i.Title == "Ballistic Missile Defense").Id,
                    Title = "More Money for BMD",
                    Abstract = "Needed to hire more experts",
                    Objective = "Something",
                    FundingAmount = 200000,
                    AnticipatedAudienceId = contextNew.AnticipatedAudiences.Single(i => i.Name == "The Public").Id,
                    VisibilityLevelId = contextNew.VisibilityLevels.Single(i => i.Name == "somewhat visible").Id,
                    FundingCategoryId = contextNew.FundingCategories.Single(i => i.Name == "Funding from OSD").Id,
                    DateSignedBySponsor = Convert.ToDateTime("5/10/2017"),
                    DateStart = Convert.ToDateTime("5/10/2017"),
                    DateEnd = Convert.ToDateTime("5/2/2018"),
                    ApprovalStatusId = contextNew.ApprovalStatuses.Single(i => i.Name == "Pending Review").Id
                },

                new Amendment
                {
                    TaskOrderId = taskOrders.Single(i => i.Title == "Reform the Pentagon").Id,
                    Title = "No cost extension to reform the Pentagon",
                    Abstract = "We didn't finish, so had to ask for more time",
                    Objective = "Something",
                    AnticipatedAudienceId = contextNew.AnticipatedAudiences.Single(i => i.Name == "The Public").Id,
                    VisibilityLevelId = contextNew.VisibilityLevels.Single(i => i.Name == "somewhat visible").Id,
                    FundingAmount = 0,
                    FundingCategoryId = contextNew.FundingCategories.Single(i => i.Name == "No Funding").Id,
                    DateSignedBySponsor = Convert.ToDateTime("5/1/2017"),
                    DateStart = Convert.ToDateTime("3/2/2018"),
                    DateEnd = Convert.ToDateTime("5/2/2018"),
                    ApprovalStatusId = contextNew.ApprovalStatuses.Single(i => i.Name == "Approved").Id
                }
            };
            foreach (var a in amendments)
            {
                contextNew.Amendments.Add(a);
            }
            contextNew.SaveChanges();

            contextNew.Deliverables.Clear();
            var deliverables = new[]
            {
                new Deliverable
                {
                    ProductTypeId = contextNew.ProductTypes.Single(i => i.Name == "External").Id,
                    Description = "Final Paper",
                    CurrentStatus = "Not finalized",
                    FormatId = contextNew.Formats.Single(i => i.Name=="Paper").Id,
                    Formal = true,
                    DateEstimatedDue = Convert.ToDateTime("5/15/2018"),
                    ContractId = taskOrders.Single(i => i.Title == "Reform the Pentagon").Id
                },
                new Deliverable
                {
                    ProductTypeId = contextNew.ProductTypes.Single(i => i.Name == "Internal").Id,
                    Description = "Final Briefing",
                    CurrentStatus = "Not finalized",
                    FormatId = contextNew.Formats.Single(i => i.Name=="Briefing").Id,
                    Formal = true,
                    DateEstimatedDue = Convert.ToDateTime("5/1/2018"),
                    ContractId = taskOrders.Single(i => i.Title == "Reform the Pentagon").Id
                }
            };

            foreach (var d in deliverables)
            {
                contextNew.Deliverables.Add(d);
            }
            contextNew.SaveChanges();

        }
    }
}
