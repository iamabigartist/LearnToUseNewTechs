﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace Doozy.Runtime.Common.Utils
{
    /// <summary> Helper class for serialization and deserialization of types </summary>
    public static class ByteArraySerializer
    {
        /// <summary> Serialize the given data type </summary>
        /// <param name="data"> Data to be serialized </param>
        /// <typeparam name="T"> Data type </typeparam>
        /// <returns> The representation of the given data as a byte array </returns>
        public static byte[] Serialize<T>(this T data)
        {
            using var ms = new MemoryStream();
            new BinaryFormatter().Serialize(ms, data);
            return ms.ToArray();
        }

        /// <summary> Deserialize the given byte array </summary>
        /// <param name="byteArray"> Byte array</param>
        /// <typeparam name="T"> Data type </typeparam>
        /// <returns> The data deserialized from the byte array </returns>
        public static T Deserialize<T>(this byte[] byteArray)
        {
            using var ms = new MemoryStream(byteArray);
            return (T)new BinaryFormatter().Deserialize(ms);
        }
    }
}
