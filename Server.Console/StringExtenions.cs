namespace mIRE.Server.Console
{
    internal static class StringExtenions
    {
        internal static byte[] ToBytes(this string value) =>
            System.Text.Encoding.ASCII.GetBytes(value);
    }
}