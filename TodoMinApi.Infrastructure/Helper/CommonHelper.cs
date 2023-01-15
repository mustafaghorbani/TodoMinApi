using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace TodoMinApi.Infrastructure.Helper
{
    public static class CommonHelper
    {
        public static List<T> GetAllInstancesOf<T>()
    => GetAllTypesOf<T>()?.Where(o => !o.IsInterface).Select(o => (T)Activator.CreateInstance(o)).ToList();

        /// <summary>
        /// The GetAllTypesOf.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <returns>The <see cref="IEnumerable{Type}"/>.</returns>
        public static IEnumerable<Type> GetAllTypesOf<T>()
            => GetLoadedType().Where(t => typeof(T).IsAssignableFrom(t));

        /// <summary>
        /// The GetLoadedType.
        /// </summary>
        /// <param name="defineTypes">The defineTypes<see cref="bool"/>.</param>
        /// <returns>The <see cref="IEnumerable{Type}"/>.</returns>
        public static IEnumerable<Type> GetLoadedType(bool defineTypes = false)
        {
            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);

            var assemblies = runtimeAssemblyNames.Select(Assembly.Load);
            return defineTypes ? assemblies.SelectMany(a => a.DefinedTypes) : assemblies.SelectMany(a => a.ExportedTypes);
        }

    }
}
