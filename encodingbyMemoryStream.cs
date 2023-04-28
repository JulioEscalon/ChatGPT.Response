public static Encoding GetFileEncoding(MemoryStream memoryStream)
{
    byte[] buffer = memoryStream.GetBuffer();
    if (buffer.Length >= 3 && buffer[0] == 0xEF && buffer[1] == 0xBB && buffer[2] == 0xBF)
    {
        return Encoding.UTF8;
    }
    else if (buffer.Length >= 2 && buffer[0] == 0xFF && buffer[1] == 0xFE)
    {
        return Encoding.Unicode;
    }
    else if (buffer.Length >= 2 && buffer[0] == 0xFE && buffer[1] == 0xFF)
    {
        return Encoding.BigEndianUnicode;
    }
    else if (buffer.Length >= 4 && buffer[0] == 0x00 && buffer[1] == 0x00 && buffer[2] == 0xFE && buffer[3] == 0xFF)
    {
        return Encoding.UTF32;
    }
    else if (buffer.Length >= 4 && buffer[0] == 0xFF && buffer[1] == 0xFE && buffer[2] == 0x00 && buffer[3] == 0x00)
    {
        return Encoding.UTF32;
    }
    else if (buffer.Length >= 4 && buffer[0] == 0x2B && buffer[1] == 0x2F && buffer[2] == 0x76 && (buffer[3] == 0x38 || buffer[3] == 0x39 || buffer[3] == 0x2B || buffer[3] == 0x2F))
    {
        return Encoding.UTF7;
    }
    else if (buffer.Length >= 4 && buffer[0] == 0x2B && buffer[1] == 0x2F && buffer[2] == 0x76 && buffer[3] == 0x38)
    {
        return Encoding.UTF7;
    }
    else
    {
        return Encoding.Default;
    }
}
