using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.tmlpaks.commons.src
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = true)]
    public class HideInspectorDerived : Attribute
    {
        public readonly Type m_derivedtype;
        public readonly string m_fieldname;

        public HideInspectorDerived(Type derivedtype) // Hide from specific derived type
        {
            m_derivedtype = derivedtype;
            m_fieldname = "";
        }

        public HideInspectorDerived()           // Hide from all descendants
        {
            m_derivedtype = null;
            m_fieldname = "";
        }

        public HideInspectorDerived(string fieldName) // Hide field from class
        {
            m_derivedtype = null;
            m_fieldname = fieldName;
        }
    }


    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = true)]
    public class InspectorLabel : Attribute
    {
        public readonly string m_label;
        public readonly Type m_derivedtype;
        public readonly string m_fieldname;

        public InspectorLabel(string label)            // relabel field
        {
            m_label = label;
            m_derivedtype = null;
            m_fieldname = "";
        }

        public InspectorLabel(string label, Type derivedtype)    // relabel field for specific  derived type
        {
            m_label = label;
            m_derivedtype = derivedtype;
            m_fieldname = "";
        }

        public InspectorLabel(string fieldName, string label)  // relabel field for class
        {
            m_label = label;
            m_derivedtype = null;
            m_fieldname = fieldName;
        }
    }

#if UNITY_EDITOR

    //[UnityEditor.CustomEditor(typeof(MonoBehaviour), true)]
    //[CanEditMultipleObjects()]
    public class CustomInspectorAttribEditor : UnityEditor.Editor
    {
        struct CustomFieldInfo
        {
            public bool m_displayField;
            public string m_label;
        };

        Dictionary<string, CustomFieldInfo> m_customField = new Dictionary<string, CustomFieldInfo>();

        protected virtual void OnEnable()
        {
            Type monoType = this.target.GetType();
            FieldInfo[] componentFields = monoType.GetFields(BindingFlags.Instance | BindingFlags.Public);
            FieldInfo[] declaredtFields = monoType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            CustomFieldInfo custominfo;

            foreach (FieldInfo field in componentFields)
            {
                bool customField = false;

                custominfo.m_displayField = false;
                custominfo.m_label = "";

                InspectorLabel labelattrib = Attribute.GetCustomAttribute(field, typeof(InspectorLabel)) as InspectorLabel;

                if ((labelattrib != null) && ((labelattrib.m_derivedtype == null) || labelattrib.m_derivedtype.IsAssignableFrom(monoType)))
                {
                    custominfo.m_label = labelattrib.m_label;
                    custominfo.m_displayField = true;
                    customField = true;
                }

                HideInspectorDerived hidederived = Attribute.GetCustomAttribute(field, typeof(HideInspectorDerived)) as HideInspectorDerived;

                if (hidederived != null)
                {

                    if ((hidederived.m_derivedtype != null) && hidederived.m_derivedtype.IsAssignableFrom(monoType))
                    {
                        custominfo.m_displayField = false;
                        customField = true;
                    }
                    else if ((hidederived.m_derivedtype == null) && (!declaredtFields.Contains(field)))
                    {
                        custominfo.m_displayField = false;
                        customField = true;
                    }
                }

                if (customField && !m_customField.ContainsKey(field.Name))
                    m_customField.Add(field.Name, custominfo);
            }

            HideInspectorDerived[] hidelist = monoType.GetCustomAttributes(typeof(HideInspectorDerived), false) as HideInspectorDerived[];
            if ((hidelist != null) && (hidelist.Length > 0))
            {
                custominfo.m_displayField = false;
                custominfo.m_label = "";

                foreach (HideInspectorDerived hide in hidelist)
                {
                    if (hide.m_fieldname != "")
                    {

                        if (m_customField.ContainsKey(hide.m_fieldname))
                        {
                            m_customField[hide.m_fieldname] = custominfo; // overwrite existing info...
                        }
                        else
                        {
                            m_customField.Add(hide.m_fieldname, custominfo);
                        }
                    }
                }
            }

            InspectorLabel[] labellist = monoType.GetCustomAttributes(typeof(InspectorLabel), false) as InspectorLabel[];
            if ((labellist != null) && (labellist.Length > 0))
            {
                custominfo.m_displayField = true;
                custominfo.m_label = "";

                foreach (InspectorLabel label in labellist)
                {
                    if ((label.m_fieldname != "") && (label.m_label != ""))
                    {
                        custominfo.m_label = label.m_label;
                        if (m_customField.ContainsKey(label.m_fieldname))
                        {
                            m_customField[label.m_fieldname] = custominfo; // overwrite existing info...
                        }
                        else
                        {
                            m_customField.Add(label.m_fieldname, custominfo);
                        }
                    }
                }
            }
        }
        ////////////////////////////////

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        }
        ////////////////////////////////

        public new bool DrawDefaultInspector()
        {
            this.serializedObject.Update();

            if (this.serializedObject == null)
                throw new System.ArgumentNullException("serializedObject");

            MonoBehaviour mono = serializedObject.targetObject as MonoBehaviour;
            Type monoType = mono.GetType();

            EditorGUI.BeginChangeCheck();

            SerializedProperty iter = serializedObject.GetIterator();
            GUIContent label = new GUIContent();
            CustomFieldInfo info;
            bool enterChildren = true;

            while (iter.NextVisible(enterChildren))
            {
                if (m_customField != null && m_customField.TryGetValue(iter.name, out info))
                {
                    if (info.m_displayField)
                    {
                        if (info.m_label != "")
                        {
                            label.text = info.m_label;
                            EditorGUILayout.PropertyField(iter, label, true);
                        }
                        else
                        {
                            EditorGUILayout.PropertyField(iter, true);
                        }
                    }
                }
                else
                {
                    EditorGUILayout.PropertyField(iter, true);
                }

                enterChildren = false;
            }

            bool result = EditorGUI.EndChangeCheck();
            this.serializedObject.ApplyModifiedProperties();

            return result;
        }
    }
#endif
}
