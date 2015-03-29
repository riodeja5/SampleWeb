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
            sexes.ForEach(s => context.Sexes.Add(s));
            context.SaveChanges();
        }
    }
}