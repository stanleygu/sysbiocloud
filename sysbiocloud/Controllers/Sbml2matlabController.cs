using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.InteropServices;

namespace sysbiocloud.Controllers
{
    public class Sbml2matlabController : Controller
    {
        public ActionResult Index()
        {
            string sbml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?><sbml xmlns=\"http://www.sbml.org/sbml/level2/version4\" level=\"2\" version=\"4\"><model metaid=\"_case00027\" id=\"case00027\" name=\"case00027\"><listOfCompartments><compartment id=\"compartment\" name=\"compartment\" size=\"0.534\" units=\"volume\"/></listOfCompartments><listOfSpecies><species id=\"S1\" name=\"S1\" compartment=\"compartment\" initialAmount=\"0.015\" substanceUnits=\"substance\"/><species id=\"S2\" name=\"S2\" compartment=\"compartment\" initialAmount=\"0\" substanceUnits=\"substance\"/></listOfSpecies><listOfInitialAssignments><initialAssignment symbol=\"compartment\"><math xmlns=\"http://www.w3.org/1998/Math/MathML\"><cn> 0.534 </cn></math></initialAssignment></listOfInitialAssignments><listOfReactions><reaction id=\"reaction1\" name=\"reaction1\" reversible=\"false\" fast=\"false\"><listOfReactants><speciesReference species=\"S1\"/></listOfReactants><listOfProducts><speciesReference species=\"S2\"/></listOfProducts><kineticLaw><math xmlns=\"http://www.w3.org/1998/Math/MathML\"><apply><times/><ci> compartment </ci><ci> k </ci><ci> S1 </ci></apply></math><listOfParameters><parameter id=\"k\" value=\"100\"/></listOfParameters></kineticLaw></reaction></listOfReactions></model></sbml>";
            System.IntPtr sbmlP = (IntPtr)Marshal.StringToHGlobalAnsi(sbml);
            System.IntPtr matlabP = (IntPtr)Marshal.StringToHGlobalAnsi(sbml);
            //return NativeMethods.validateSBMLString(sbmlP).ToString();

            NativeMethods.sbml2matlab(sbmlP, ref matlabP);

            ViewBag.sbml = sbml;
            ViewBag.mfile = Marshal.PtrToStringAnsi(matlabP);


            return View();
        }

        public partial class NativeConstants
        {

            /// DLL_EXPORT -> __declspec(dllexport)
            /// Error generating expression: Error generating function call.  Operation not implemented
            public const string DLL_EXPORT = "__declspec(dllexport)";
        }

        public partial class NativeMethods
        {

            /// Return Type: int
            ///sbmlInput: char*
            ///matlabOutput: char**
            [System.Runtime.InteropServices.DllImportAttribute("libsbml2matlab.dll", EntryPoint = "sbml2matlab")]
            public static extern int sbml2matlab(System.IntPtr sbmlInput, ref System.IntPtr matlabOutput);


            /// Return Type: void
            ///matlabInput: char*
            [System.Runtime.InteropServices.DllImportAttribute("libsbml2matlab.dll", EntryPoint = "freeMatlabString")]
            public static extern void freeMatlabString(System.IntPtr matlabInput);


            /// Return Type: char*
            [System.Runtime.InteropServices.DllImportAttribute("libsbml2matlab.dll", EntryPoint = "getNomErrors")]
            public static extern System.IntPtr getNomErrors();


            /// Return Type: int
            [System.Runtime.InteropServices.DllImportAttribute("libsbml2matlab.dll", EntryPoint = "getNumSbmlErrors")]
            public static extern int getNumSbmlErrors();


            /// Return Type: int
            ///index: int
            ///line: int*
            ///column: int*
            ///errorId: int*
            ///errorType: char**
            ///errorMsg: char**
            [System.Runtime.InteropServices.DllImportAttribute("libsbml2matlab.dll", EntryPoint = "getNthSbmlError")]
            public static extern int getNthSbmlError(int index, ref int line, ref int column, ref int errorId, ref System.IntPtr errorType, ref System.IntPtr errorMsg);


            /// Return Type: int
            ///cSBML: char*
            [System.Runtime.InteropServices.DllImportAttribute("libsbml2matlab.dll", EntryPoint = "validateSBMLString")]
            public static extern int validateSBMLString(System.IntPtr cSBML);

            /// Return Type: char*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getError")]
            public static extern System.IntPtr getError();


            /// Return Type: int
            ///sbmlStr: char*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "loadSBML")]
            public static extern int loadSBML(System.IntPtr sbmlStr);


            /// Return Type: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumErrors")]
            public static extern int getNumErrors();


            /// Return Type: int
            ///index: int
            ///line: int*
            ///column: int*
            ///errorId: int*
            ///errorType: char**
            ///errorMsg: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthError")]
            public static extern int getNthError(int index, ref int line, ref int column, ref int errorId, ref System.IntPtr errorType, ref System.IntPtr errorMsg);


            /// Return Type: int
            ///cSBML: char*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "validateSBML")]
            public static extern int validateSBML(System.IntPtr cSBML);


            /// Return Type: int
            ///sId: char*
            ///isInitialAmount: boolean*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "hasInitialAmount")]
            public static extern int hasInitialAmount(System.IntPtr sId, ref bool isInitialAmount);


            /// Return Type: int
            ///cId: char*
            ///hasInitial: int*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "hasInitialConcentration")]
            public static extern int hasInitialConcentration(System.IntPtr cId, ref int hasInitial);


            /// Return Type: int
            ///sId: char*
            ///value: double*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getValue")]
            public static extern int getValue(System.IntPtr sId, ref double value);


            /// Return Type: int
            ///sId: char*
            ///dValue: double
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "setValue")]
            public static extern int setValue(System.IntPtr sId, double dValue);


            /// Return Type: int
            ///sbmlStr: char*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "validate")]
            public static extern int validate(System.IntPtr sbmlStr);


            /// Return Type: int
            ///name: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getModelName")]
            public static extern int getModelName(ref System.IntPtr name);


            /// Return Type: int
            ///sId: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getModelId")]
            public static extern int getModelId(ref System.IntPtr sId);


            /// Return Type: int
            ///cId: char*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "setModelId")]
            public static extern int setModelId(System.IntPtr cId);


            /// Return Type: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumFunctionDefinitions")]
            public static extern int getNumFunctionDefinitions();


            /// Return Type: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumCompartments")]
            public static extern int getNumCompartments();


            /// Return Type: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumReactions")]
            public static extern int getNumReactions();


            /// Return Type: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumFloatingSpecies")]
            public static extern int getNumFloatingSpecies();


            /// Return Type: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumBoundarySpecies")]
            public static extern int getNumBoundarySpecies();


            /// Return Type: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumGlobalParameters")]
            public static extern int getNumGlobalParameters();


            /// Return Type: int
            ///nIndex: int
            ///name: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthGlobalParameterName")]
            public static extern int getNthGlobalParameterName(int nIndex, ref System.IntPtr name);


            /// Return Type: int
            ///nIndex: int
            ///sId: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthGlobalParameterId")]
            public static extern int getNthGlobalParameterId(int nIndex, ref System.IntPtr sId);


            /// Return Type: int
            ///index: int
            ///fnId: char**
            ///numArgs: int*
            ///argList: char***
            ///body: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthFunctionDefinition")]
            public static extern int getNthFunctionDefinition(int index, ref System.IntPtr fnId, ref int numArgs, ref System.IntPtr argList, ref System.IntPtr body);


            /// Return Type: int
            ///nIndex: int
            ///name: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthCompartmentName")]
            public static extern int getNthCompartmentName(int nIndex, ref System.IntPtr name);


            /// Return Type: int
            ///nIndex: int
            ///sId: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthCompartmentId")]
            public static extern int getNthCompartmentId(int nIndex, ref System.IntPtr sId);


            /// Return Type: int
            ///cId: char*
            ///compId: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getCompartmentIdBySpeciesId")]
            public static extern int getCompartmentIdBySpeciesId(System.IntPtr cId, ref System.IntPtr compId);


            /// Return Type: int
            ///IdList: char***
            ///numFloat: int*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getListOfFloatingSpeciesIds")]
            public static extern int getListOfFloatingSpeciesIds(ref System.IntPtr IdList, ref int numFloat);


            /// Return Type: int
            ///nIndex: int
            ///name: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthFloatingSpeciesName")]
            public static extern int getNthFloatingSpeciesName(int nIndex, ref System.IntPtr name);


            /// Return Type: int
            ///nIndex: int
            ///sId: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthFloatingSpeciesId")]
            public static extern int getNthFloatingSpeciesId(int nIndex, ref System.IntPtr sId);


            /// Return Type: int
            ///IdList: char***
            ///numBoundary: int*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getListOfBoundarySpeciesIds")]
            public static extern int getListOfBoundarySpeciesIds(ref System.IntPtr IdList, ref int numBoundary);


            /// Return Type: int
            ///nIndex: int
            ///name: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthBoundarySpeciesName")]
            public static extern int getNthBoundarySpeciesName(int nIndex, ref System.IntPtr name);


            /// Return Type: int
            ///nIndex: int
            ///sId: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthBoundarySpeciesId")]
            public static extern int getNthBoundarySpeciesId(int nIndex, ref System.IntPtr sId);


            /// Return Type: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumRules")]
            public static extern int getNumRules();


            /// Return Type: int
            ///nIndex: int
            ///rule: char**
            ///ruleType: int*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthRule")]
            public static extern int getNthRule(int nIndex, ref System.IntPtr rule, ref int ruleType);


            /// Return Type: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumEvents")]
            public static extern int getNumEvents();


            /// Return Type: int
            ///nIndex: int
            ///name: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthReactionName")]
            public static extern int getNthReactionName(int nIndex, ref System.IntPtr name);


            /// Return Type: int
            ///arg: int
            ///isReversible: int*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "isReactionReversible")]
            public static extern int isReactionReversible(int arg, ref int isReversible);


            /// Return Type: int
            ///nIndex: int
            ///sId: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthReactionId")]
            public static extern int getNthReactionId(int nIndex, ref System.IntPtr sId);


            /// Return Type: int
            ///arg: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumReactants")]
            public static extern int getNumReactants(int arg);


            /// Return Type: int
            ///arg: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumProducts")]
            public static extern int getNumProducts(int arg);


            /// Return Type: int
            ///arg1: int
            ///arg2: int
            ///name: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthReactantName")]
            public static extern int getNthReactantName(int arg1, int arg2, ref System.IntPtr name);


            /// Return Type: int
            ///arg1: int
            ///arg2: int
            ///name: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthProductName")]
            public static extern int getNthProductName(int arg1, int arg2, ref System.IntPtr name);


            /// Return Type: int
            ///index: int
            ///kineticLaw: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getKineticLaw")]
            public static extern int getKineticLaw(int index, ref System.IntPtr kineticLaw);


            /// Return Type: double
            ///arg1: int
            ///arg2: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthReactantStoichiometry")]
            public static extern double getNthReactantStoichiometry(int arg1, int arg2);


            /// Return Type: double
            ///arg1: int
            ///arg2: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthProductStoichiometry")]
            public static extern double getNthProductStoichiometry(int arg1, int arg2);


            /// Return Type: int
            ///reactionIndex: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNumLocalParameters")]
            public static extern int getNumLocalParameters(int reactionIndex);


            /// Return Type: int
            ///reactionIndex: int
            ///parameterIndex: int
            ///sId: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthLocalParameterName")]
            public static extern int getNthLocalParameterName(int reactionIndex, int parameterIndex, ref System.IntPtr sId);


            /// Return Type: int
            ///reactionIndex: int
            ///parameterIndex: int
            ///sId: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthLocalParameterId")]
            public static extern int getNthLocalParameterId(int reactionIndex, int parameterIndex, ref System.IntPtr sId);


            /// Return Type: int
            ///reactionIndex: int
            ///parameterIndex: int
            ///value: double*
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getNthLocalParameterValue")]
            public static extern int getNthLocalParameterValue(int reactionIndex, int parameterIndex, ref double value);


            /// Return Type: int
            ///inSBML: char*
            ///outSBML: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "getParamPromotedSBML")]
            public static extern int getParamPromotedSBML(System.IntPtr inSBML, ref System.IntPtr outSBML);


            /// Return Type: int
            ///inSBML: char*
            ///outSBML: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "addMissingModifiers")]
            public static extern int addMissingModifiers(System.IntPtr inSBML, ref System.IntPtr outSBML);


            /// Return Type: int
            ///mathMLStr: char*
            ///infix: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "convertMathMLToString")]
            public static extern int convertMathMLToString(System.IntPtr mathMLStr, ref System.IntPtr infix);


            /// Return Type: int
            ///infixStr: char*
            ///mathMLStr: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "convertStringToMathML")]
            public static extern int convertStringToMathML(System.IntPtr infixStr, ref System.IntPtr mathMLStr);


            /// Return Type: int
            ///sbml: char**
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "reorderRules")]
            public static extern int reorderRules(ref System.IntPtr sbml);


            /// Return Type: int
            ///inputModel: char*
            ///outputModel: char**
            ///nLevel: int
            ///nVersion: int
            [System.Runtime.InteropServices.DllImportAttribute("NOM.dll", EntryPoint = "convertSBML")]
            public static extern int convertSBML(System.IntPtr inputModel, ref System.IntPtr outputModel, int nLevel, int nVersion);

        }
    }
}
