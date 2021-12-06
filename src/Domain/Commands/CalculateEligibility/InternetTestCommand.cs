using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.CalculateEligibility
{
    public record InternetTestCommand(double DownloadSpeed, double UploadSpeed);

}
