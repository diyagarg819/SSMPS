using Microsoft.Extensions.Logging;
using SSPMS.Application.Interfaces;

namespace SSPMS.Infrastructure.Services;

/// <summary>
/// Development-only email service that logs all emails to the console
/// instead of sending them via SMTP. This allows full testing without
/// needing a real Gmail App Password.
/// </summary>
public class DevEmailService : IEmailService
{
    private readonly ILogger<DevEmailService> _logger;

    public DevEmailService(ILogger<DevEmailService> logger) => _logger = logger;

    public Task SendAsync(string to, string subject, string htmlBody)
    {
        _logger.LogInformation(
            "\n╔══════════════════════════════════════════════════════════════╗\n" +
            "║                    📧 EMAIL SENT (DEV)                     ║\n" +
            "╠══════════════════════════════════════════════════════════════╣\n" +
            "║ To:      {To}\n" +
            "║ Subject: {Subject}\n" +
            "╚══════════════════════════════════════════════════════════════╝",
            to, subject);
        return Task.CompletedTask;
    }

    public Task SendWelcomeEmailAsync(string to, string name, string tempPassword)
    {
        _logger.LogInformation(
            "\n📧 [DEV EMAIL] Welcome email to {To}\n" +
            "   Name: {Name} | Temp Password: {TempPassword}",
            to, name, tempPassword);
        return Task.CompletedTask;
    }

    public Task SendEmailVerificationOtpAsync(string to, string name, string otp)
    {
        _logger.LogInformation(
            "\n" +
            "╔══════════════════════════════════════════════════════════════╗\n" +
            "║              📧 EMAIL VERIFICATION OTP (DEV)               ║\n" +
            "╠══════════════════════════════════════════════════════════════╣\n" +
            "║ To:   {To}\n" +
            "║ Name: {Name}\n" +
            "║ OTP:  >>>  {Otp}  <<<\n" +
            "╚══════════════════════════════════════════════════════════════╝",
            to, name, otp);
        return Task.CompletedTask;
    }

    public Task SendOtpEmailAsync(string to, string name, string otp)
    {
        _logger.LogInformation(
            "\n" +
            "╔══════════════════════════════════════════════════════════════╗\n" +
            "║              📧 PASSWORD RESET OTP (DEV)                   ║\n" +
            "╠══════════════════════════════════════════════════════════════╣\n" +
            "║ To:   {To}\n" +
            "║ Name: {Name}\n" +
            "║ OTP:  >>>  {Otp}  <<<\n" +
            "╚══════════════════════════════════════════════════════════════╝",
            to, name, otp);
        return Task.CompletedTask;
    }

    public Task SendTaskAssignedEmailAsync(string to, string name, string taskTitle, DateTime startAt, DateTime endAt)
    {
        _logger.LogInformation(
            "\n📧 [DEV EMAIL] Task Assigned → {To}\n" +
            "   Task: {TaskTitle} | Start: {StartAt} | End: {EndAt}",
            to, taskTitle, startAt, endAt);
        return Task.CompletedTask;
    }

    public Task SendTaskEvaluatedEmailAsync(string to, string name, string taskTitle, decimal finalScore)
    {
        _logger.LogInformation(
            "\n📧 [DEV EMAIL] Task Evaluated → {To}\n" +
            "   Task: {TaskTitle} | Score: {Score}",
            to, taskTitle, finalScore);
        return Task.CompletedTask;
    }

    public Task SendDeadlineReminderEmailAsync(string to, string name, string taskTitle, DateTime endAt)
    {
        _logger.LogInformation(
            "\n📧 [DEV EMAIL] Deadline Reminder → {To}\n" +
            "   Task: {TaskTitle} | Ends: {EndAt}",
            to, taskTitle, endAt);
        return Task.CompletedTask;
    }

    public Task SendBadgeEarnedEmailAsync(string to, string name, string badgeName, string badgeDescription)
    {
        _logger.LogInformation(
            "\n📧 [DEV EMAIL] Badge Earned → {To}\n" +
            "   Badge: {BadgeName}",
            to, badgeName);
        return Task.CompletedTask;
    }

    public Task SendWeeklyDigestAsync(string to, string trainerName, string className, object digestData)
    {
        _logger.LogInformation(
            "\n📧 [DEV EMAIL] Weekly Digest → {To}\n" +
            "   Class: {ClassName}",
            to, className);
        return Task.CompletedTask;
    }
}
