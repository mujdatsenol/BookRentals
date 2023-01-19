using BookRentals.Domain;

namespace BookRentals.Persistence
{
    public static class MemberSeed
    {
        public static List<Member> Members()
        {
            Guid member1 = new Guid("5B5ABA2C-068C-4850-86AB-A4E2ECA325ED");
            Guid member2 = new Guid("06500DC8-F77B-417D-BB5D-0D6AC7E3661A");
            Guid member3 = new Guid("284E5EA4-32DA-4643-84B9-B7A889F9FE78");
            Guid member4 = new Guid("0D3818C5-7C5E-4E12-BA06-7FB3B391C933");
            Guid member5 = new Guid("5E9B7161-3BB9-4E02-BC5B-788925450042");

            return new List<Member>()
            {
                new Member
                {
                    Id = member1,
                    IdentityNumber = "1",
                    FirstName = "Ahmet",
                    LastName = "Ünlü"
                },
                new Member
                {
                    Id = member2,
                    IdentityNumber = "2",
                    FirstName = "Hasan",
                    LastName = "Usta"
                },
                new Member()
                {
                    Id = member3,
                    IdentityNumber = "3",
                    FirstName = "Elif",
                    LastName = "Gül"
                },
                new Member()
                {
                    Id = member4,
                    IdentityNumber = "4",
                    FirstName = "Mehmet",
                    LastName = "Taşçı"
                },
                new Member()
                {
                    Id = member5,
                    IdentityNumber = "5",
                    FirstName = "Melike",
                    LastName = "Gezer"
                }
            };
        }
    }
}
