// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "It is appropriate", Scope = "member", Target = "~P:MessageQueue.Domain.Settings.AppSettings.AllowedHosts")]
[assembly: SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix", Justification = "It is appropriate", Scope = "type", Target = "~T:MessageQueue.Domain.Models.ActiveQueue")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "By design", Scope = "member", Target = "~P:MessageQueue.Domain.Models.ActiveQueue.Messages")]
