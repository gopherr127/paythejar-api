using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayTheJarApi.AppUser;
using PayTheJarApi.Jar;
using RandomNameGenerator;

namespace PayTheJarApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            JarRepository repo = new JarRepository();
            var results = await repo.GetAll(1);
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            JarRepository repo = new JarRepository();

            for (int i = 0; i < 101; i++)
            {
                await repo.Add(new Jar.Jar()
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
        public async Task TestMethod3()
        {
            AppUserRepository repo = new AppUserRepository();
            Random rdm = new Random();

            for (int i = 0; i < 101; i++)
            {
                string firstName = NameGenerator.GenerateFirstName((Gender)rdm.Next(0,1));
                firstName = firstName.Substring(0, 1) + firstName.Substring(1).ToLower();
                string lastName = NameGenerator.GenerateLastName();
                lastName = lastName.Substring(0, 1) + lastName.Substring(1).ToLower();
                string userName = firstName.ToLower() + lastName;
                string avatarUrl = "https://api.adorable.io/avatars/" + rdm.Next(235, 3571);

                await repo.Add(new AppUser.AppUser()
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
    }
}
