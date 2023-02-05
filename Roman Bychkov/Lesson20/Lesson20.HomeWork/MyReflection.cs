using System.Reflection;
using System.Text;

public static class MyReflection
{
    public static string GetPropertyInfo(PropertyInfo obj)
    {
        StringBuilder result = new StringBuilder($"{obj.PropertyType.Name} {obj.Name} {{");


        if (obj.CanRead)
        {
            result.Append(GetModificator(obj.GetMethod) + " get;");
        }

        if (obj.CanWrite) result.Append(GetModificator(obj.SetMethod) + " set;");
        result.Append("}");
        return result.ToString();
    }

    public static string GetFieldInfo(FieldInfo obj)
    {

        StringBuilder modificator = new StringBuilder();
        StringBuilder generic = new StringBuilder();
        if (obj.IsPublic)
            modificator.Append("public");
        else if (obj.IsPrivate)
            modificator.Append("private");
        else if (obj.IsAssembly)
            modificator.Append("internal");
        else if (obj.IsFamily)
            modificator.Append("protected");
        else if (obj.IsFamilyAndAssembly)
            modificator.Append("private protected");
        else if (obj.IsFamilyOrAssembly)
            modificator.Append("protected internal");
        if (obj.IsStatic) modificator.Append(" static");

        if (obj.FieldType.IsGenericType)
        {
            generic.Append(GetGenerics(obj.FieldType.GenericTypeArguments));
        }
        else
            generic.Append("");

        return $"{modificator} {obj.FieldType.Name} {generic.ToString()} {obj.Name}";

    }
    public static string GetMethodBaseInfo(MethodBase obj)
    {
        string modificator = GetModificator(obj);
        StringBuilder param = new StringBuilder("(");
        StringBuilder generic = new StringBuilder();
        ParameterInfo[] parameters = obj.GetParameters();
        for (int i = 0; i < parameters.Length; i++)
        {
            if (parameters[i].IsIn)
                param.Append("in ");
            if (parameters[i].IsOut)
                param.Append("out ");
            if (parameters[i].ParameterType.IsByRef)
                param.Append("ref ");
            if (parameters[i].ParameterType.IsGenericType)
            {
                generic.Append(GetGenerics(parameters[i].ParameterType.GenericTypeArguments));
            }
            param.Append(parameters[i].ParameterType.Name + generic + " " + parameters[i].Name);
            generic.Clear();

            if (parameters[i].IsOptional)
            {
                if (parameters[i].DefaultValue == null)
                    param.Append(" = null");
                else
                    param.Append(" = " + parameters[i].DefaultValue);

            }

            if (i < parameters.Length - 1)
                param.Append(", ");

        }
        param.Append(")");
        if (obj is ConstructorInfo ctor)
            return $"{modificator} {ctor.DeclaringType} {param}";
        if (obj is MethodInfo method)
        {
            if (method.ReturnType.IsGenericType)
            {
                generic.Append(GetGenerics(method.ReturnType.GenericTypeArguments));
            }
            return $"{modificator} {method.ReturnType.Name}{generic} {method.Name} {param}";
        }
        else return "";
    }
    public static string GetEventInfo(EventInfo obj)
    {
        StringBuilder modificator = new StringBuilder();
        if (obj.IsMulticast)
            modificator.Append("multicast ");
        if (obj.IsCollectible)
            modificator.Append("collectible ");
        return $"{modificator} {obj.EventHandlerType.Name} {obj.Name}";
    }
    public static string GetModificator(MethodBase obj)
    {
        StringBuilder modificator = new StringBuilder();
        if (obj.IsPublic)
            modificator.Append("public");
        else if (obj.IsPrivate)
            modificator.Append("private");
        else if (obj.IsAssembly)
            modificator.Append("internal");
        else if (obj.IsFamily)
            modificator.Append("protected");
        else if (obj.IsFamilyAndAssembly)
            modificator.Append("private protected");
        else if (obj.IsFamilyOrAssembly)
            modificator.Append("protected internal");
        if (obj.IsStatic) modificator.Append(" static");
        return modificator.ToString();
    }
    public static string GetGenerics(Type[] type)
    {
        StringBuilder generic = new StringBuilder();
        for (int j = 0; j < type.Length; j++)
        {
            if (j == 0)
                generic.Append("<");
            generic.Append(type[j].Name);
            if (j < type.Length - 1)
                generic.Append(",");
            if (j + 1 == type.Length)
                generic.Append(">");

        }
        return generic.ToString();
    }
}