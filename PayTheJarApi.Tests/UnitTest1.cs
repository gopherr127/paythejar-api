using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayTheJarApi.AppUsers;
using PayTheJarApi.Fouls;
using PayTheJarApi.Jars;
using RandomNameGenerator;

namespace PayTheJarApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task GetAllJars()
        {
            JarRepository repo = new JarRepository();
            var results = await repo.GetAll(1);
        }

        [TestMethod]
        public async Task AddJars()
        {
            int numJarsToCreate = 50;
            JarRepository repo = new JarRepository();
            
            for (int i = 0; i < numJarsToCreate; i++)
            {
                await repo.Add(new Jar()
                {
                    Name = "Jar " + i,
                    Category = "Uncategorized",
                    CurrentAmount = i + 0.50,
                    CreatedBy = "user::grodgers",
                    CreatedDate = DateTime.UtcNow.ToString()
                });
            }
        }

        [TestMethod]
        public async Task AddAppUsers()
        {
            int numAppUsersToCreate = 50;
            AppUserRepository repo = new AppUserRepository();
            Random rdm = new Random();

            for (int i = 0; i < numAppUsersToCreate; i++)
            {
                string firstName = NameGenerator.GenerateFirstName((Gender)rdm.Next(0,1));
                firstName = firstName.Substring(0, 1) + firstName.Substring(1).ToLower();
                string lastName = NameGenerator.GenerateLastName();
                lastName = lastName.Substring(0, 1) + lastName.Substring(1).ToLower();
                string userName = firstName.ToLower() + lastName;
                string avatarUrl = "https://api.adorable.io/avatars/" + rdm.Next(235, 3571);

                await repo.Add(new AppUser()
                {
                    UserName = userName,
                    FirstName = firstName,
                    LastName = lastName,
                    AvatarUrl = avatarUrl,
                    Location = "Nowhere",
                    RegistrationDate = DateTime.UtcNow.ToString()
                });
            }
        }

        [TestMethod]
        public async Task AddFouls()
        {
            int numFoulsToCreate = 1;
            FoulRepository repo = new FoulRepository();
            Random rdm = new Random();

            for (int i = 0; i < numFoulsToCreate; i++)
            {
                int randomNum = rdm.Next(2345, 45873249);
                int ones = rdm.Next(0, 1);
                int tenths = rdm.Next(0, 9);
                int hundredths = rdm.Next(0, 9);

                await repo.Add(new Foul()
                {
                    Name = "Foul " + randomNum,
                    Description = "Description of Foul " + randomNum,
                    PenaltyAmount = Convert.ToDouble(
                        ones.ToString() + "." + tenths.ToString() + hundredths.ToString())
                });
            }
        }
    }
}
