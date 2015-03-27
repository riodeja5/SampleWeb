using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace SumidaWeb.Models
{
    public class SumidaWebInitializer : DropCreateDatabaseAlways<SumidaWebContext>
    {
        protected override void Seed(SumidaWebContext context)
        {
            var members = new List<Member> {
                new Member {
                    Name = "角田祥太",
                    Email = "riodeja_5_shota@hotmail.com",
                    Birty = DateTime.Parse("1981-12-15"),
                    Married = true
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

            members.ForEach(m => context.Members.Add(m));
            sexes.ForEach(s => context.Sexes.Add(s));
            context.SaveChanges();
        }
    }
}