using System;
using Unity.Container.Registration;

namespace GpwEditor.Presentation.Console.DependencyInjection.Unity
{
    public static class UnityContainerRegistrationExtension
    {
        public static string GetMappingAsString(this ContainerRegistration registration)
        {
            var r = registration.RegisteredType;
            var regType = r.Name + GetGenericArgumentsList(r);

            var m = registration.MappedToType;
            var mapTo = m.Name + GetGenericArgumentsList(m);

            var regName = registration.Name ?? "[default]";

            var lifetime = registration.LifetimeManager.LifetimeType.Name;
            if (mapTo != regType)
            {
                mapTo = " -> " + mapTo;
            }
            else
            {
                mapTo = string.Empty;
            }
            lifetime = lifetime.Substring(0, lifetime.Length - "LifetimeManager".Length);
            return $"+ {regType}{mapTo}  '{regName}'  {lifetime}";
        }

        private static string GetGenericArgumentsList(Type type)
        {
            if (type.GetGenericArguments().Length == 0) return "";
            var arglist = "";
            var first = true;
            foreach (var t in type.GetGenericArguments())
            {
                arglist += first ? t.Name : ", " + t.Name;
                first = false;
                if (t.GetGenericArguments().Length > 0)
                {
                    arglist += GetGenericArgumentsList(t);
                }
            }
            return "<" + arglist + ">";
        }
    }
}