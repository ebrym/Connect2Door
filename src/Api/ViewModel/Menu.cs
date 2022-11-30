namespace Api.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuDataItem
    {
        /// <summary>
        /// Submenu
        /// </summary>
        MenuDataItem[] Children { get; set; }
        /// <summary>
        /// Hide children
        /// </summary>
        bool HideChildrenInMenu { get; set; }
        /// <summary>
        /// Hide
        /// </summary>
        bool HideInMenu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Icon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool Locale { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool Disabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string[] ParentKeys { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool FlatMenu { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class MenuItem : MenuDataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Component { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string[] Authority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool HideMenu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Redirect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MenuItem[] Routes { get; set; }


    }
}
