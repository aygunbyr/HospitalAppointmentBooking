namespace App.Models.Models
{
    public static class Branch
    {
        public const string GeneralPractice = "General Practice";
        public const string Pediatrics = "Pediatrics";
        public const string Surgery = "Surgery";
        public const string Cardiology = "Cardiology";
        public const string Dermatology = "Dermatology";

        public static string[] GetAllBranches()
        {
            return new string[]
            {
                GeneralPractice,
                Pediatrics,
                Surgery,
                Cardiology,
                Dermatology
            };
        }
    }
}
