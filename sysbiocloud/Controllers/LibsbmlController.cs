using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.InteropServices;

namespace sysbiocloud.Controllers
{
    public class LibsbmlController : Controller
    {
        /// Return Type: char*
        [System.Runtime.InteropServices.DllImportAttribute("libsbml.dll", EntryPoint = "getLibSBMLVersionString")]
        public static extern System.IntPtr getLibSBMLVersionString();
        /// Return Type: int
        [System.Runtime.InteropServices.DllImportAttribute("libsbml.dll", EntryPoint = "getLibSBMLVersion")]
        public static extern int getLibSBMLVersion();
        /// Return Type: char*
        [System.Runtime.InteropServices.DllImportAttribute("libsbml.dll", EntryPoint = "getLibSBMLDottedVersion")]
        public static extern System.IntPtr getLibSBMLDottedVersion();

        /// Return Type: int
        ///str: char*
        ///sim_time: double
        ///dt: double
        ///print_interval: int
        ///print_amount: int
        ///method: int
        ///use_lazy_method: int
        [System.Runtime.InteropServices.DllImportAttribute("sbmlsim.dll", EntryPoint = "simulateSBMLFromString")]
        public static extern System.IntPtr simulateSBMLFromString([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string str, double sim_time, double dt, int print_interval, int print_amount, int method, int use_lazy_method);

        public ActionResult Index()
        {
            //return libsbml.getLibSBMLVersionString();

            //IntPtr ptr = getLibSBMLVersionString();
            //string str = Marshal.PtrToStringAuto(ptr);

            string sbml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?><sbml xmlns=\"http://www.sbml.org/sbml/level2/version4\" level=\"2\" version=\"4\"><model metaid=\"_case00027\" id=\"case00027\" name=\"case00027\"><listOfCompartments><compartment id=\"compartment\" name=\"compartment\" size=\"0.534\" units=\"volume\"/></listOfCompartments><listOfSpecies><species id=\"S1\" name=\"S1\" compartment=\"compartment\" initialAmount=\"0.015\" substanceUnits=\"substance\"/><species id=\"S2\" name=\"S2\" compartment=\"compartment\" initialAmount=\"0\" substanceUnits=\"substance\"/></listOfSpecies><listOfInitialAssignments><initialAssignment symbol=\"compartment\"><math xmlns=\"http://www.w3.org/1998/Math/MathML\"><cn> 0.534 </cn></math></initialAssignment></listOfInitialAssignments><listOfReactions><reaction id=\"reaction1\" name=\"reaction1\" reversible=\"false\" fast=\"false\"><listOfReactants><speciesReference species=\"S1\"/></listOfReactants><listOfProducts><speciesReference species=\"S2\"/></listOfProducts><kineticLaw><math xmlns=\"http://www.w3.org/1998/Math/MathML\"><apply><times/><ci> compartment </ci><ci> k </ci><ci> S1 </ci></apply></math><listOfParameters><parameter id=\"k\" value=\"100\"/></listOfParameters></kineticLaw></reaction></listOfReactions></model></sbml>";
            IntPtr myresult = simulateSBMLFromString(sbml, 10.0, 0.1, 1, 1, 41, 0);

            //Marshal.PtrToStructure(myresult,)

            IntPtr ptr = getLibSBMLDottedVersion();
            ViewBag.libsbmlVersion = Marshal.PtrToStringAnsi(ptr);

            return View();
        }
    }
}
