using System;

namespace Syncfusion.Addin
{
    /// <summary>
    /// Attribute to be specified for each Innosys bundle to specify
    /// which class is the bundle activator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class AddInAttribute : Attribute
    {
        /// <summary>
        /// ����
        /// </summary>
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string _description;

        /// <summary>
        /// ����
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _publisher;

        /// <summary>
        /// ��Ȩ
        /// </summary>
        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }

        private string _version;

        /// <summary>
        /// �汾
        /// </summary>
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public AddInAttribute(string name)
        {
            this.name = name;
        }
    }
}