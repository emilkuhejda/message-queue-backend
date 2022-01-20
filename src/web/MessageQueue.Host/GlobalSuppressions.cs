// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "By design", Scope = "type", Target = "~T:MessageQueue.Host.Program")]
[assembly: SuppressMessage("Design", "CA1019:Define accessors for attribute arguments", Justification = "By design", Scope = "member", Target = "~M:MessageQueue.Host.Filters.ApiExceptionFilter.#ctor(Serilog.ILogger)")]
