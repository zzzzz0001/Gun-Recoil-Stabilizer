using System.Reflection;

namespace Gun_recoil_stabilizer.Utils
{
    class AssemblyHelper   //something fully useless to me
    {
        //
        // Members
        //
        #region Members

        // Current assembly
        private Assembly mAssembly;

        #endregion

        //
        // Public methods
        //
        #region Public methods

        // Constructor
        public AssemblyHelper()
        {
            mAssembly = Assembly.GetExecutingAssembly();
        }

        #endregion

        //
        // Properties
        //
        #region Properties

        // Title property
        public string Title
        {
            get { return mAssembly.GetCustomAttribute<AssemblyTitleAttribute>().Title; }
        }

        // Description property
        public string Description
        {
            get { return mAssembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description; }
        }

        // Configuration property
        public string Configuration
        {
            get { return mAssembly.GetCustomAttribute<AssemblyConfigurationAttribute>().Configuration; }
        }

        // Company property
        public string Company
        {
            get { return mAssembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company; }
        }

        // Product property
        public string Product
        {
            get { return mAssembly.GetCustomAttribute<AssemblyProductAttribute>().Product; }
        }

        // Copyright property
        public string Copyright
        {
            get { return mAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright; }
        }

        // Trademark property
        public string Trademark
        {
            get { return mAssembly.GetCustomAttribute<AssemblyTrademarkAttribute>().Trademark; }
        }

        // Version property
        public string Version
        {
            get { return mAssembly.GetName().Version.ToString(); }
        }

        #endregion
    }
}
