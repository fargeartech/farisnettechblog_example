namespace BenchmarkDotNetExample
{
    public sealed class Enums
    {
        public enum UserType
        {
            Guest,
            Staff,
            Admin
        }

        public static string GetFastEnum(UserType userType)
        {
            switch (userType)
            {
                case UserType.Guest:
                    return nameof(userType.Guest);
                case UserType.Staff:
                    return nameof(userType.Staff);
                case UserType.Admin: return nameof(userType.Admin);
                default:
                    return userType.ToString();
            }
        }
    }
}