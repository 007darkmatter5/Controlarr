﻿namespace Shared.Entities.Sonarr
{
	public class SonarrSystemStatus
	{
		public string AppName { get; set; }
		public string InstanceName { get; set; }
		public string Version { get; set; }
		public DateTime BuildTime { get; set; }
		public bool IsDebug { get; set; }
		public bool IsProduction { get; set; }
		public bool IsAdmin { get; set; }
		public bool IsUserInteractive { get; set; }
		public string StartupPath { get; set; }
		public string AppData { get; set; }
		public string OsName { get; set; }
		public string OsVersion { get; set; }
		public bool IsNetCore { get; set; }
		public bool IsLinux { get; set; }
		public bool IsOsx { get; set; }
		public bool IsWindows { get; set; }
		public bool IsDocker { get; set; }
		public string Mode { get; set; }
		public string Branch { get; set; }
		public string Authentication { get; set; }
		public string SqliteVersion { get; set; }
		public int MigrationVersion { get; set; }
		public string UrlBase { get; set; }
		public string RuntimeVersion { get; set; }
		public string RuntimeName { get; set; }
		public DateTime StartTime { get; set; }
		public string PackageVersion { get; set; }
		public string PackageAuthor { get; set; }
		public string PackageUpdateMechanism { get; set; }
		public string PackageUpdateMechanismMessage { get; set; }
		public string DatabaseVersion { get; set; }
		public string DatabaseType { get; set; }
	}
}
