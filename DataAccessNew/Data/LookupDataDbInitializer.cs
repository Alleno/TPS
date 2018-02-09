using System.Linq;
using TPS.Core.Models;

namespace DataAccessNew.Data
{
    public class LookupDataDbInitializer
    {
        public static void Initialize(DataContextNew contextNew)
        {
            contextNew.Database.EnsureCreated();

            if (contextNew.Contracts.Any())
            {
            }

            else
            {
                contextNew.FundingCategories.Clear();
                var fundingCategories = new[]
                {
                    new FundingCategory{ Name = "No Funding"},
                    new FundingCategory{ Name = "Funding from IDA Overhead"},
                    new FundingCategory{ Name = "Funding from OSD"},
                    new FundingCategory{ Name = "Funding from Services"},
                    new FundingCategory{ Name = "Some other type of funding"}
                };
                foreach (var c in fundingCategories)
                {
                    contextNew.FundingCategories.Add(c);
                }
                contextNew.SaveChanges();

                contextNew.AnticipatedAudiences.Clear();
                var anticipatedAudiences = new[]
                {
                    new AnticipatedAudience{ Name = "Nobody" },
                    new AnticipatedAudience{ Name = "IDA only"},
                    new AnticipatedAudience{ Name = "Sponsor only"},
                    new AnticipatedAudience{ Name = "DoD at large"},
                    new AnticipatedAudience{ Name = "The Public"}
                };
                foreach (var a in anticipatedAudiences)
                {
                    contextNew.AnticipatedAudiences.Add(a);
                }
                contextNew.SaveChanges();


                contextNew.VisibilityLevels.Clear();
                var visibilityLevels = new[]
                {
                    new VisibilityLevel{ Name = "completely invisible" },
                    new VisibilityLevel{ Name = "shouldn't see the light of day"},
                    new VisibilityLevel{ Name = "somewhat visible"},
                    new VisibilityLevel{ Name = "very visible"},
                    new VisibilityLevel{ Name = "Seen by hubble telescope"}
                };
                foreach (var v in visibilityLevels)
                {
                    contextNew.VisibilityLevels.Add(v);
                }
                contextNew.SaveChanges();

                contextNew.ApprovalStatuses.Clear();
                var approvalStatuses = new[]
                {
                    new ApprovalStatus{ Name = "Proposed" },
                    new ApprovalStatus{ Name = "Pending Approval"},
                    new ApprovalStatus{ Name = "Approved" },
                    new ApprovalStatus{ Name = "Denied" },
                    new ApprovalStatus{ Name = "Pending Review" }
                };
                foreach (var s in approvalStatuses)
                {
                    contextNew.ApprovalStatuses.Add(s);
                }
                contextNew.SaveChanges();

                contextNew.Formats.Clear();
                var formats = new[]
                {
                    new Format{ Name = "Meeting" },
                    new Format{ Name = "Briefing"},
                    new Format{ Name = "Powerpoint Slides" },
                    new Format{ Name = "Paper" },
                    new Format{ Name = "Computer Code" }
                };
                foreach (var f in formats)
                {
                    contextNew.Formats.Add(f);
                }
                contextNew.SaveChanges();

                contextNew.ProductTypes.Clear();
                var productTypes = new[]
                {
                    new ProductType { Name = "Internal"},
                    new ProductType { Name = "External"}
                };
                foreach (var p in productTypes)
                {
                    contextNew.ProductTypes.Add(p);
                }

                contextNew.EmployeeTypes.Clear();
                var employeeTypes = new[]
                {
                    new EmployeeType{ Name = "RA" },
                    new EmployeeType{ Name = "RSM"},
                    new EmployeeType{ Name = "Deputy Director" },
                    new EmployeeType{ Name = "Director" },
                    new EmployeeType{ Name = "MDA" },
                    new EmployeeType{ Name = "Admin" }
                };
                foreach (var e in employeeTypes)
                {
                    contextNew.EmployeeTypes.Add(e);
                }
                contextNew.SaveChanges();

                contextNew.CRPCategories.Clear();
                var CRPCategories = new[]
                {
                    new CRPCategory {Name = "Division Discretionary"},
                    new CRPCategory {Name = "Corporate"}
                };
                foreach (var c in CRPCategories)
                {
                    contextNew.CRPCategories.Add(c);
                }

                contextNew.SaveChanges();

                contextNew.SFRDProgramAreas.Clear();
                var SFRDProgramAreas = new[]
                {
                    new SFRDProgramArea {Name = "CBRN"},
                    new SFRDProgramArea {Name = "Materials"},
                    new SFRDProgramArea {Name = "Human Capital"},
                    new SFRDProgramArea {Name = "Risk"}
                };
                foreach (var p in SFRDProgramAreas)
                {
                    contextNew.SFRDProgramAreas.Add(p);
                }

                contextNew.SaveChanges();

                contextNew.IDACoreAreas.Clear();
                var IDACoreAreas = new[]
                {
                    new IDACoreArea {Name = "Procurement"},
                    new IDACoreArea {Name = "Systems Evaluation"},
                    new IDACoreArea {Name = "DoD Management"},
                    new IDACoreArea {Name = "Risk"}
                };
                foreach (var a in IDACoreAreas)
                {
                    contextNew.IDACoreAreas.Add(a);
                }

                contextNew.SaveChanges();

            }
        }
    }
}
