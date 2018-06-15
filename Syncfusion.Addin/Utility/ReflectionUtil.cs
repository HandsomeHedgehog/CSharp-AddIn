using Syncfusion.Addin.Core.Reflection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Syncfusion.Addin.Utility
{
    /// <summary>
    /// Class ReflectionUtil.
    /// </summary>
    public static class ReflectionUtil
    {
        // Methods

        /// <summary>
        /// ��ȡ����Ŀ¼
        /// </summary>
        /// <param name="assembly">����</param>
        /// <returns>�ļ�·��</returns>
        public static string GetAssemblyFilename(Assembly assembly)
        {
            return assembly.CodeBase.Replace("file:///", "").Replace('/', '\\');
        }

        /// <summary>
        /// ��ȡ����İ汾��Ϣ
        /// </summary>
        /// <param name="assembly">����</param>
        /// <returns>���ذ汾��   �磺1.0.0.0</returns>
        public static string GetAssemblyVersion(Assembly assembly)
        {
            foreach (string part in assembly.FullName.Split(','))
            {
                string trimmed = part.Trim();

                if (trimmed.StartsWith("Version="))
                    return trimmed.Substring(8);
            }

            return "0.0.0.0";
        }

        /// <summary>
        /// ��ȡ�Զ���������Ϣ
        /// </summary>
        /// <param name="assembly">����</param>
        /// <param name="attribute">����</param>
        /// <returns>AttributeInfo[] ����</returns>
        public static AttributeInfo[] GetCustomAttributes(Assembly assembly, Type attribute)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }
            HashSet<AttributeInfo> attributes = new HashSet<AttributeInfo>();
            foreach (Type type in assembly.GetExportedTypes())
            {
                foreach (Attribute attr in type.GetCustomAttributes(attribute, true))
                {
                    AttributeInfo attributeInfo = new AttributeInfo(type, attr);
                    attributes.Add(attributeInfo);
                }
            }
            AttributeInfo[] result = new AttributeInfo[attributes.Count];
            attributes.CopyTo(result);
            return result;
        }
    }
}