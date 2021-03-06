#region License
//
// Author: Nate Kohari <nkohari@gmail.com>
// Copyright (c) 2007-2008, Enkari, Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
#region Using Directives
using System;
using log4net;
using Ninject.Core.Logging;
#endregion

namespace Ninject.Integration.Log4net.Infrastructure
{
	/// <summary>
	/// A logger that integrates with log4net, passing all messages to an <see cref="ILog"/>.
	/// </summary>
	public class Log4netLogger : LoggerBase
	{
		/*----------------------------------------------------------------------------------------*/
		#region Fields
		private readonly ILog _log4netLogger;
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Properties
		/// <summary>
		/// Gets a value indicating whether messages with Debug severity should be logged.
		/// </summary>
		public override bool IsDebugEnabled
		{
			get { return _log4netLogger.IsDebugEnabled; }
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether messages with Info severity should be logged.
		/// </summary>
		public override bool IsInfoEnabled
		{
			get { return _log4netLogger.IsInfoEnabled; }
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether messages with Warn severity should be logged.
		/// </summary>
		public override bool IsWarnEnabled
		{
			get { return _log4netLogger.IsWarnEnabled; }
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether messages with Error severity should be logged.
		/// </summary>
		public override bool IsErrorEnabled
		{
			get { return _log4netLogger.IsErrorEnabled; }
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether messages with Fatal severity should be logged.
		/// </summary>
		public override bool IsFatalEnabled
		{
			get { return _log4netLogger.IsFatalEnabled; }
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Log4netLogger"/> class.
		/// </summary>
		/// <param name="type">The type to create a logger for.</param>
		public Log4netLogger(Type type)
			: base(type)
		{
			_log4netLogger = LogManager.GetLogger(type);
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Public Methods
		/// <summary>
		/// Logs the specified message with Debug severity.
		/// </summary>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		public override void Debug(string format, params object[] args)
		{
			_log4netLogger.DebugFormat(format, args);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified exception with Debug severity.
		/// </summary>
		/// <param name="exception">The exception to log.</param>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		public override void Debug(Exception exception, string format, params object[] args)
		{
			_log4netLogger.Debug(String.Format(format, args), exception);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified message with Info severity.
		/// </summary>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		public override void Info(string format, params object[] args)
		{
			_log4netLogger.InfoFormat(format, args);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified exception with Info severity.
		/// </summary>
		/// <param name="exception">The exception to log.</param>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		public override void Info(Exception exception, string format, params object[] args)
		{
			_log4netLogger.Info(String.Format(format, args), exception);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified message with Warn severity.
		/// </summary>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		public override void Warn(string format, params object[] args)
		{
			_log4netLogger.WarnFormat(format, args);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified exception with Warn severity.
		/// </summary>
		/// <param name="exception">The exception to log.</param>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		public override void Warn(Exception exception, string format, params object[] args)
		{
			_log4netLogger.Warn(String.Format(format, args), exception);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified message with Error severity.
		/// </summary>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		public override void Error(string format, params object[] args)
		{
			_log4netLogger.ErrorFormat(format, args);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified exception with Error severity.
		/// </summary>
		/// <param name="exception">The exception to log.</param>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		public override void Error(Exception exception, string format, params object[] args)
		{
			_log4netLogger.Error(String.Format(format, args), exception);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified message with Fatal severity.
		/// </summary>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		public override void Fatal(string format, params object[] args)
		{
			_log4netLogger.FatalFormat(format, args);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Logs the specified exception with Fatal severity.
		/// </summary>
		/// <param name="exception">The exception to log.</param>
		/// <param name="format">The message or format template.</param>
		/// <param name="args">Any arguments required for the format template.</param>
		public override void Fatal(Exception exception, string format, params object[] args)
		{
			_log4netLogger.Fatal(String.Format(format, args), exception);
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}