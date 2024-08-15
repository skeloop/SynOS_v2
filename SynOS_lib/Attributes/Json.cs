[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class SaveToJsonAttribute : Attribute
{
    public string CustomKey { get; }

    public SaveToJsonAttribute(string customKey = null)
    {
        CustomKey = customKey;
    }
}
