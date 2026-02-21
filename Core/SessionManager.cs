using System;
using System.Windows.Forms;

namespace Employeemanagment.Core
{
    public static class SessionManager
    {
        public static string CurrentUserId { get; private set; } = string.Empty;
        public static string CurrentRole { get; private set; } = string.Empty;
        public static string CurrentUserName { get; private set; } = string.Empty;

        public static void InitializeSession(string id, string role, string name)
        {
            CurrentUserId = id;
            CurrentRole = string.IsNullOrEmpty(role) ? "Employee" : role;
            CurrentUserName = string.IsNullOrEmpty(name) ? id : name;
        }

        public static void EndSession()
        {
            CurrentUserId = string.Empty;
            CurrentRole = string.Empty;
            CurrentUserName = string.Empty;
        }

        public static bool IsAdmin => CurrentRole.Equals("Admin", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Recursively disables and hides controls marked with specific tags if the user does not have permission.
        /// Expected tags: "AdminOnly"
        /// </summary>
        public static void ApplyRBAC(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control.Tag != null)
                {
                    string tagStr = control.Tag.ToString() ?? "";
                    if (tagStr.Contains("AdminOnly") && !IsAdmin)
                    {
                        control.Visible = false;
                        control.Enabled = false;
                    }
                }

                if (control.HasChildren)
                {
                    ApplyRBAC(control);
                }
            }
        }
    }
}
