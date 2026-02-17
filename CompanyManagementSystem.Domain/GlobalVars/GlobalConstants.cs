namespace CompanyManagementSystem.Domain.GlobalVars
{
    /// <summary>
    /// Application-wide global state for tracking the currently active company and user.
    /// </summary>
    public static class GlobalConstants
    {
        /// <summary>
        /// Currently selected/opened company ID.
        /// </summary>
        public static int CurrentCompanyId { get; set; }

        /// <summary>
        /// Currently logged-in user ID. 0 means no user logged in.
        /// </summary>
        public static int CurrentUserId { get; set; }

        /// <summary>
        /// Reset global state when closing a company.
        /// </summary>
        public static void Reset()
        {
            CurrentCompanyId = 0;
            CurrentUserId = 0;
        }
    }
}
