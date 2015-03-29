using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SumidaWeb.Models
{
    public class SumidaWebInitializer : DropCreateDatabaseAlways<SumidaWebContext>
    {
        protected override void Seed(SumidaWebContext context)
        {
            var rolls = new List<Roll> {
                new Roll {
                    RollName = "管理者"
                },
                new Roll {
                    RollName = "設計"
                },
                new Roll {
                    RollName = "営業"
                },
            };

            var members = new List<Member> {
                new Member {
                }
            };

            var machines = new List<Machine> {
                new Machine {
                    MachineType = "RX-78"
                },
                new Machine {
                    MachineType = "GP-01 Full Bernian"
                },
                new Machine {
                    MachineType = "GP-03 Staymen"
                }
            };

            var users = new List<User> {
                new User {
                    UserName = "ZEON"
                },
                new User {
                    UserName = "A.E.U.G"
                },
                new User {
                    UserName = "Titans"
                }
            };
/*
            var fabs = new List<Fab> {
                new Fab {
                    User = 
                    FabName = "Side3"
                },
            };
*/
            var sexes = new List<Sex> {
                new Sex {
                    Kind = "おとこ"
                },
                new Sex {
                    Kind = "おんな"
                },
                new Sex {
                    Kind = "オカマちゃん"
                }
            };

            rolls.ForEach(r => context.Rolls.Add(r));
            //            members.ForEach(m => context.Members.Add(m));
            machines.ForEach(machine => context.Machines.Add(machine));
            users.ForEach(u => context.Users.Add(u));
            sexes.ForEach(s => context.Sexes.Add(s));
            context.SaveChanges();
        }
    }
}