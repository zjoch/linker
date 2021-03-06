﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Diagnostics.CodeAnalysis
{
	/// <summary>
	/// Indicates that certain members on a specified <see cref="Type"/> are accessed dynamically,
	/// for example through <see cref="System.Reflection"/>.
	/// </summary>
	/// <remarks>
	/// This allows tools to understand which members are being accessed during the execution
	/// of a program.
	///
	/// This attribute is valid on members whose type is <see cref="Type"/> or <see cref="string"/>.
	///
	/// When this attribute is applied to a location of type <see cref="string"/>, the assumption is
	/// that the string represents a fully qualified type name.
	/// 
	/// This is a copy of the code from framework at https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/Diagnostics/CodeAnalysis/DynamicallyAccessedMembersAttribute.cs
	/// </remarks>
	[AttributeUsage (
		AttributeTargets.Field | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter |
		AttributeTargets.Parameter | AttributeTargets.Property |
		AttributeTargets.Method, // This is used only to mark the "this" parameter - it should not appear in public API for this attribute (and we don't support it on anything but System.Type)
		Inherited = false)]
	public sealed class DynamicallyAccessedMembersAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DynamicallyAccessedMembersAttribute"/> class
		/// with the specified member types.
		/// </summary>
		/// <param name="memberTypes">The types of members dynamically accessed.</param>
		public DynamicallyAccessedMembersAttribute (DynamicallyAccessedMemberTypes memberTypes)
		{
			MemberTypes = memberTypes;
		}

		/// <summary>
		/// Gets the <see cref="DynamicallyAccessedMemberTypes"/> which specifies the type
		/// of members dynamically accessed.
		/// </summary>
		public DynamicallyAccessedMemberTypes MemberTypes { get; }
	}
}
