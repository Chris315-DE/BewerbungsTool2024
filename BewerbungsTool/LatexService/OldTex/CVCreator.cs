using BewerbungsTool.Manager;
using BewerbungsTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BewerbungsTool.LatexService
{
    public class CVCreator
    {
        LebenslaufTemplate Lebenslauf { get; set; }

        string SavePath;
        string FilePath;

        public CVCreator(LebenslaufTemplate lebenslauf)
        {
            Lebenslauf = lebenslauf;
            SavePath = Path.Combine(AppContext.BaseDirectory, "Lebenslauf");

            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            int countfiles = 0;
            var files = Directory.GetFiles(SavePath);
            foreach (var file in files)
            {
                if (file.Contains(".tex"))
                    countfiles++;
            }


            //LTexMetaEnde();

            FilePath = Path.Combine(SavePath, $"CV{countfiles}.tex");


            WriteandSave();
        }

        //fürs Testen der RightColum 


        #region LeftCol
        #region Const

        //  \begin{leftcolumn}
        private const string LATEX_SETUP = @"%-----------------------------------------------------------------------------------------------------------------------------------------------%
%	The MIT License (MIT)
%
%	Copyright (c) 2019 Jan Küster
%
%	Permission is hereby granted, free of charge, to any person obtaining a copy
%	of this software and associated documentation files (the ""Software""), to deal
%	in the Software without restriction, including without limitation the rights
%	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
%	copies of the Software, and to permit persons to whom the Software is
%	furnished to do so, subject to the following conditions:
%	
%	THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
%	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
%	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
%	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
%	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
%	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
%	THE SOFTWARE.
%	
%
%-----------------------------------------------------------------------------------------------------------------------------------------------%


%============================================================================%
%
%	DOCUMENT DEFINITION
%
%============================================================================%

\documentclass[10pt,A4,english]{article}	


%----------------------------------------------------------------------------------------
%	ENCODING
%----------------------------------------------------------------------------------------

% we use utf8 since we want to build from any machine
\usepackage[utf8]{inputenc}		
\usepackage[ngerman]{isodate}
\usepackage{fancyhdr}
\usepackage[numbers]{natbib}

%----------------------------------------------------------------------------------------
%	LOGIC
%----------------------------------------------------------------------------------------

% provides \isempty test
\usepackage{xstring, xifthen}
\usepackage{enumitem}
\usepackage[ngerman]{babel}
\usepackage{blindtext}
\usepackage{pdfpages}
\usepackage{changepage}

%----------------------------------------------------------------------------------------
%	FONT BASICS
%----------------------------------------------------------------------------------------

% some tex-live fonts - choose your own

%\usepackage[defaultsans]{droidsans}
%\usepackage[default]{comfortaa}
%\usepackage{cmbright}
\usepackage[default]{raleway}
%\usepackage{fetamont}
%\usepackage[default]{gillius}
%\usepackage[light,math]{iwona}
%\usepackage[thin]{roboto} 

% set font default
\renewcommand*\familydefault{\sfdefault} 	
\usepackage[T1]{fontenc}

% more font size definitions
\usepackage{moresize}

%----------------------------------------------------------------------------------------
%	FONT AWESOME ICONS
%---------------------------------------------------------------------------------------- 

% include the fontawesome icon set
\usepackage{fontawesome}

% use to vertically center content
% credits to: http://tex.stackexchange.com/questions/7219/how-to-vertically-center-two-images-next-to-each-other
\newcommand{\vcenteredinclude}[1]{\begingroup
\setbox0=\hbox{\includegraphics{#1}}%
\parbox{\wd0}{\box0}\endgroup}
\newcommand{\tab}[1]{\hspace{.2\textwidth}\rlap{#1}}
% use to vertically center content
% credits to: http://tex.stackexchange.com/questions/7219/how-to-vertically-center-two-images-next-to-each-other
\newcommand*{\vcenteredhbox}[1]{\begingroup
\setbox0=\hbox{#1}\parbox{\wd0}{\box0}\endgroup}

% icon shortcut
\newcommand{\icon}[3] { 							
	\makebox(#2, #2){\textcolor{maincol}{\csname fa#1\endcsname}}
}	


% icon with text shortcut
\newcommand{\icontext}[4]{ 						
	\vcenteredhbox{\icon{#1}{#2}{#3}}  \hspace{2pt}  \parbox{0.9\mpwidth}{\textcolor{#4}{#3}}
}

% icon with website url
\newcommand{\iconhref}[5]{ 						
    \vcenteredhbox{\icon{#1}{#2}{#5}}  \hspace{2pt} \href{#4}{\textcolor{#5}{#3}}
}

% icon with email link
\newcommand{\iconemail}[5]{ 						
    \vcenteredhbox{\icon{#1}{#2}{#5}}  \hspace{2pt} \href{mailto:#4}{\textcolor{#5}{#3}}
}

%----------------------------------------------------------------------------------------
%	PAGE LAYOUT  DEFINITIONS
%----------------------------------------------------------------------------------------

% page outer frames (debug-only)
% \usepackage{showframe}		

% we use paracol to display breakable two columns
\usepackage{paracol}
\usepackage{tikzpagenodes}
\usetikzlibrary{calc}
\usepackage{lmodern}
\usepackage{multicol}
\usepackage{lipsum}
\usepackage{atbegshi}
% define page styles using geometry
\usepackage[a4paper]{geometry}

% remove all possible margins
\geometry{top=1cm, bottom=1cm, left=1cm, right=1cm}

\usepackage{fancyhdr}
\pagestyle{empty}

% space between header and content
% \setlength{\headheight}{0pt}

% indentation is zero
\setlength{\parindent}{0mm}

%----------------------------------------------------------------------------------------
%	TABLE /ARRAY DEFINITIONS
%---------------------------------------------------------------------------------------- 

% extended aligning of tabular cells
\usepackage{array}

% custom column right-align with fixed width
% use like p{size} but via x{size}
\newcolumntype{x}[1]{%
>{\raggedleft\hspace{0pt}}p{#1}}%


%----------------------------------------------------------------------------------------
%	GRAPHICS DEFINITIONS
%---------------------------------------------------------------------------------------- 

%for header image
\usepackage{graphicx}

% use this for floating figures
% \usepackage{wrapfig}
% \usepackage{float}
% \floatstyle{boxed} 
% \restylefloat{figure}

%for drawing graphics		
\usepackage{tikz}			
\usepackage{ragged2e}	
\usetikzlibrary{shapes, backgrounds,mindmap, trees}

%----------------------------------------------------------------------------------------
%	Color DEFINITIONS
%---------------------------------------------------------------------------------------- 
\usepackage{transparent}
\usepackage{color}

% primary color
\definecolor{maincol}{RGB}{ 64,64,64}

% accent color, secondary
% \definecolor{accentcol}{RGB}{ 250, 150, 10 }

% dark color
\definecolor{darkcol}{RGB}{ 70, 70, 70 }

% light color
\definecolor{lightcol}{RGB}{245,245,245}

\definecolor{accentcol}{RGB}{59,77,97}



% Package for links, must be the last package used
\usepackage[hidelinks]{hyperref}

% returns minipage width minus two times \fboxsep
% to keep padding included in width calculations
% can also be used for other boxes / environments
\newcommand{\mpwidth}{\linewidth-\fboxsep-\fboxsep}
	


%============================================================================%
%
%	CV COMMANDS
%
%============================================================================%

%----------------------------------------------------------------------------------------
%	 CV LIST
%----------------------------------------------------------------------------------------

% renders a standard latex list but abstracts away the environment definition (begin/end)
\newcommand{\cvlist}[1] {
	\begin{itemize}{#1}\end{itemize}
}

%----------------------------------------------------------------------------------------
%	 CV TEXT
%----------------------------------------------------------------------------------------

% base class to wrap any text based stuff here. Renders like a paragraph.
% Allows complex commands to be passed, too.
% param 1: *any
\newcommand{\cvtext}[1] {
	\begin{tabular*}{1\mpwidth}{p{0.98\mpwidth}}
		\parbox{1\mpwidth}{#1}
	\end{tabular*}
}
\newcommand{\cvtextsmall}[1] {
	\begin{tabular*}{0.8\mpwidth}{p{0.8\mpwidth}}
		\parbox{0.8\mpwidth}{#1}
	\end{tabular*}
}
%----------------------------------------------------------------------------------------
%	CV SECTION
%----------------------------------------------------------------------------------------

% Renders a a CV section headline with a nice underline in main color.
% param 1: section title
\newlength{\barw}
\newcommand{\cvsection}[1] {
	\vspace{14pt}
	\settowidth{\barw}{\textbf{\LARGE #1}}
	\cvtext{
		\textbf{\LARGE{\textcolor{darkcol}{#1}}}\\[-4pt]
		\textcolor{accentcol}{ \rule{\barw}{1.5pt} } \\
	}
}

\newcommand{\cvsubsection}[1] {
	\vspace{14pt}
	\settowidth{\barw}{\textbf{\Large #1}}
	\cvtext{
		\textbf{\Large{\textcolor{darkcol}{#1}}}\\[-4pt]
		\textcolor{accentcol}{ \rule{\barw}{1.5pt} } \\
	}
}

\newcommand{\cvheadline}[1] {
	\vspace{16pt}
	\cvtext{
		\textbf{\Huge{\textcolor{accentcol}{#1}}}\\[-4pt]
		 
	}
}

\newcommand{\cvsubheadline}[1] {
	\vspace{16pt}
	\cvtext{
		\textbf{\huge{\textcolor{darkcol}{#1}}}\\[-4pt]
		 
	}
}
%----------------------------------------------------------------------------------------
%	META SKILL
%----------------------------------------------------------------------------------------

% Renders a progress-bar to indicate a certain skill in percent.
% param 1: name of the skill / tech / etc.
% param 2: level (for example in years)
% param 3: percent, values range from 0 to 1
\newcommand{\cvskill}[3] {
	\begin{tabular*}{1\mpwidth}{p{0.72\mpwidth}  r}
 		\textcolor{black}{\textbf{#1}} & \textcolor{maincol}{#2}\\
	\end{tabular*}%
	
	\hspace{4pt}
	\begin{tikzpicture}[scale=1,rounded corners=2pt,very thin]
		\fill [lightcol] (0,0) rectangle (1\mpwidth, 0.15);
		\fill [accentcol] (0,0) rectangle (#3\mpwidth, 0.15);
  	\end{tikzpicture}%
}


%----------------------------------------------------------------------------------------
%	 CV EVENT
%----------------------------------------------------------------------------------------

% Renders a table and a paragraph (cvtext) wrapped in a parbox (to ensure minimum content
% is glued together when a pagebreak appears).
% Additional Information can be passed in text or list form (or other environments).
% the work you did
% param 1: time-frame i.e. Sep 14 - Jan 15 etc.
% param 2:	 event name (job position etc.)
% param 3: Customer, Employer, Industry
% param 4: Short description
% param 5: work done (optional)
% param 6: technologies include (optional)
% param 7: achievements (optional)
\newcommand{\cvevent}[7] {
	
	% we wrap this part in a parbox, so title and description are not separated on a pagebreak
	% if you need more control on page breaks, remove the parbox
	\parbox{\mpwidth}{
		\begin{tabular*}{1\mpwidth}{p{0.66\mpwidth}  r}
	 		\textcolor{black}{\textbf{#2}} & \colorbox{accentcol}{\makebox[0.3\mpwidth]{\textcolor{white}{\textbf{#1}}}} \\
			\textcolor{maincol}{#3} & \\
		\end{tabular*}\\[8pt]
	
		\ifthenelse{\isempty{#4}}{}{
			\cvtext{#4}\\
		}
	}
	\vspace{14pt}
}


%----------------------------------------------------------------------------------------
%	 CV META EVENT
%----------------------------------------------------------------------------------------

% Renders a CV event on the sidebar
% param 1: title
% param 2: subtitle (optional)
% param 3: customer, employer, etc,. (optional)
% param 4: info text (optional)
\newcommand{\cvmetaevent}[4] {
	\textcolor{maincol} { \cvtext{\textbf{\begin{flushleft}#1\end{flushleft}}}}

	\ifthenelse{\isempty{#2}}{}{
	\textcolor{black} {\cvtext{\textbf{#2}} }
	}

	\ifthenelse{\isempty{#3}}{}{
		\cvtext{{ \textcolor{maincol} {#3} }}\\
	}

	\cvtext{#4}\\[14pt]
}

%---------------------------------------------------------------------------------------
%	QR CODE
%----------------------------------------------------------------------------------------

% Renders a qrcode image (centered, relative to the parentwidth)
% param 1: percent width, from 0 to 1
\newcommand{\cvqrcode}[1] {
	\begin{center}
		\includegraphics[width={#1}\mpwidth]{qrcode}
	\end{center}
}


% HEADER AND FOOOTER 
%====================================
\newcommand\Header[1]{%
\begin{tikzpicture}[remember picture,overlay]
\fill[accentcol]
  (current page.north west) -- (current page.north east) --
  ([yshift=50pt]current page.north east|-current page text area.north east) --
  ([yshift=50pt,xshift=-3cm]current page.north|-current page text area.north) --
  ([yshift=10pt,xshift=-5cm]current page.north|-current page text area.north) --
  ([yshift=10pt]current page.north west|-current page text area.north west) -- cycle;
\node[font=\sffamily\bfseries\color{white},anchor=west,
  xshift=0.7cm,yshift=-0.32cm] at (current page.north west)
  {\fontsize{12}{12}\selectfont {#1}};
\end{tikzpicture}%
}

\newcommand\Footer[1]{%
\begin{tikzpicture}[remember picture,overlay]
\fill[lightcol]
  (current page.south east) -- (current page.south west) --
  ([yshift=-80pt]current page.south east|-current page text area.south east) --
  ([yshift=-80pt,xshift=-6cm]current page.south|-current page text area.south) --
  ([xshift=-2.5cm,yshift=-10pt]current page.south|-current page text area.south) --	
  ([yshift=-10pt]current page.south east|-current page text area.south east) -- cycle;
\node[yshift=0.32cm,xshift=9cm] at (current page.south) {\fontsize{10}{10}\selectfont \textbf{\thepage}};
\end{tikzpicture}%
}


%=====================================
%============================================================================%
%
%
%
%	DOCUMENT CONTENT
%
%
%
%============================================================================%
\begin{document}

\columnratio{0.31}
\setlength{\columnsep}{2.2em}
\setlength{\columnseprule}{4pt}
\colseprulecolor{white}


% LEBENSLAUF HIERE
\AtBeginShipoutFirst{\Header{CV}\Footer{1}}
\AtBeginShipout{\AtBeginShipoutAddToBox{\Header{CV}\Footer{2}}}

\newpage

\colseprulecolor{lightcol}
\columnratio{0.31}
\setlength{\columnsep}{2.2em}
\setlength{\columnseprule}{4pt}
\begin{paracol}{2}


\begin{leftcolumn}";

        private const string LATEX_META_SKILLS_KOMMENTAR = @"%---------------------------------------------------------------------------------------
%	META SKILLS
%----------------------------------------------------------------------------------------";

        private const string LATEX_META_BILDUNG_KOMMENTAR = @"%---------------------------------------------------------------------------------------
%	EDUCATION
%----------------------------------------------------------------------------------------";

        private const string LATEX_END_LEFT_START_RIGHT = @"\end{leftcolumn}
\begin{rightcolumn}";


        private const string LATEX_END = @"\end{rightcolumn}
											\end{paracol}
											\end{document}";


        private const string LTEX_WORK_EXP_COMMENT = @"%---------------------------------------------------------------------------------------
%	WORK EXPERIENCE
%----------------------------------------------------------------------------------------

\vspace{10pt}
\cvsection{Berufserfahrung}
\vspace{4pt}
";



        private const string HOTFIX = @"% hofixes to create fake-space to ensure the whole height is used
\newpage
\mbox{}
\vfill
\mbox{}
\vfill
\mbox{}
\vfill
\mbox{}
\vfill
\mbox{}
\vfill
\mbox{}
\vfill
\mbox{}
";

        #endregion
        private string LTexMeta_Person()
        {
            string? name = Lebenslauf?.PersonenInfo?.Name;
            if (string.IsNullOrEmpty(name))
                return default;

            //string? name
            //string? geburtsDaten
            //string? beruf
            //string? nationalität
            //string? familienstand
            /* 
             *  string Ltex1 = @"\fcolorbox{white}{white}{\begin{minipage}[c][1.5cm][c]{1\mpwidth}
							\LARGE{\textbf{\textcolor{maincol}{";


            Ltex1 = Ltex1 += name += @"}}} \\[2pt]
				\normalsize{ \textcolor{maincol} {";
            Ltex1 = Ltex1 += beruf += @"} }
									\end{minipage}} \\
									\icontext{CaretRight}{12}{";
            Ltex1 = Ltex1 += geburtsDaten += @"}{black}\\[6pt]
												\icontext{CaretRight}{12}{";

            Ltex1 = Ltex1 += nationalität += @"}{black}\\[6pt]
											\icontext{CaretRight}{12}{";

            Ltex1 = Ltex1 += familienstand += @"}{black}\\[6pt]";
             */

            string? geburtsDaten = Lebenslauf?.PersonenInfo?.GeburtsDaten;
            if (string.IsNullOrEmpty(geburtsDaten))
                return default;


            string? beruf = Lebenslauf?.PersonenInfo?.Beruf;
            if (string.IsNullOrEmpty(beruf))
            {
                beruf = "";
            }

            string? nationalität = Lebenslauf?.PersonenInfo?.Nationalität;
            if (string.IsNullOrEmpty(nationalität))
                nationalität = "deutsch";

            string? familienstand = Lebenslauf?.PersonenInfo?.Familienstand;
            if (string.IsNullOrEmpty(familienstand))
                familienstand = string.Empty;


            string Ltex1 = @"\fcolorbox{white}{white}{\begin{minipage}[c][1.5cm][c]{1\mpwidth}
							\LARGE{\textbf{\textcolor{maincol}{";


            Ltex1 = Ltex1 += name += @"}}} \\[2pt]
				\normalsize{ \textcolor{maincol} {";
            Ltex1 = Ltex1 += beruf += @"} }
									\end{minipage}} \\
									\icontext{CaretRight}{12}{";
            Ltex1 = Ltex1 += geburtsDaten += @"}{black}\\[6pt]
												\icontext{CaretRight}{12}{";

            Ltex1 = Ltex1 += nationalität += @"}{black}\\[6pt]
											\icontext{CaretRight}{12}{";

            Ltex1 = Ltex1 += familienstand += @"}{black}\\[6pt]";


            return Ltex1;

        }


        private string LTexMeta_Kontakt()
        {
            string ret = @"\cvsection{Kontakt}" + "\n";
            string black = @"}{black}\\[6pt]" + "\n";
            foreach (var item in Lebenslauf.Kontakt)
            {

                string conv = convertUnicodeStringtoLTexFormat(item.Index, item.Content);
                ret += conv;


            }


            return ret;
        }

        private string LTexMeta_Skills()
        {

            List<string> formattetList = [];
            string stringtoReturn = @"\cvsection{Fähigkeiten}" + "\n";
            string format = string.Empty;
            var skillliste = Lebenslauf.Stats;
            if (skillliste != null && skillliste.Count > 0)
            {
                foreach (var item in skillliste)
                {
                    format = FormatStatToLTEX(item.Fähigkeit, ConvertValue(item.SliderValue), item.SliderValue);

                    formattetList.Add(format);


                }
            }

            foreach (var item in formattetList)
            {
                stringtoReturn += item;
                stringtoReturn += "\n";

            }
            return stringtoReturn;

        }


        private string ConvertValue(string value)
        {
            switch (value)
            {
                case "1":
                    return "Anfänger";
                case "2":
                    return "Anfänger+";
                case "3":
                    return "Grundkenntnisse";
                case "4":
                    return "Fortgeschritten";
                case "5":
                    return "Kompetent";
                case "6":
                    return "Geübt";
                case "7":
                    return "Erfahren";
                case "8":
                    return "Versiert";
                case "9":
                    return "Profi";
                case "10":
                    return "Experte";
                default:
                    return "Unwissend";

            }
        }



        private string FormatStatToLTEX(string statname, string value, string score)
            => @"\cvskill{" + statname + @"} {" + value + "} {" + (float.Parse(score) / 10).ToString().Replace(',', '.') + @"} \\[-2pt]";




        private string LTexMeta_Bildung()
        {
            string cvsection = @"\newline" + "\n" + @"\cvsection{Bildung}" + "\n";
            string Event = @"\cvmetaevent" + "\n";

            string ret = cvsection;

            foreach (var item in Lebenslauf.Bildung)
            {
                ret += Event;
                ret += "{" + item.VonBis + "}\n";
                ret += "{" + item.Was + "}\n";
                ret += "{" + item.Wo + "}\n";
                ret += @"{\textit{" + item.Beschreibung + "}}\n";
            }

            return ret;
        }



        private string LTexMeta_Projekte()
        {
            if (Lebenslauf.Projekt.Count == 0)
                return string.Empty;
            string cvsec = @"\cvsection{Projekte}" + "\n\n";
            string ret = cvsec += @"\cvlist{" + "\n";
            foreach (var item in Lebenslauf.Projekt)
            {
                ret += @"\item {\textbf{" + item.ProjektName + @"}}\\" + item.Beschreibung + "\n";
            }
            ret += "}\n";

            return ret;
        }

        private string LTexMeta_Hobbys()
        {
            string cvsection = @"\cvsection{Interessen}" + "\n\n";
            string ico = @"\icontext{CaretRight}{12}{";
            string icoend = @"}{black}\\[6pt]" + "\n";
            string ret = cvsection;
            if (Lebenslauf?.Hobbys.Count > 0)
            {

                foreach (var item in Lebenslauf.Hobbys)
                {
                    ret += ico;
                    ret += item.Text;
                    ret += icoend;
                }
            }
            return ret;
        }



        private string convertUnicodeStringtoLTexFormat(int index, string content)
        {

            switch (index)
            {
                //GitHub
                case 0:
                    string splittet = string.Empty;
                    if (content.Contains("www"))
                    {
                        splittet = content.Replace("https://www.github.com/", "");

                    }
                    else
                    {
                        splittet = content.Replace("https://github.com/", "");
                    }


                    return @"\iconhref{Github}{16}{" + splittet + @"}{" + content + @"}{black}\\[6pt]" + "\n";

                //Mail
                case 1:
                    return @"\iconemail{Envelope}{16}{" + content + @"}{" + content + @"}{black}\\[6pt]" + "\n";

                //Phone
                case 2:
                    return @"\icontext{MobilePhone}{16}{" + content + @"}{black}\\[6pt]" + "\n";

                //Xing
                case 3:

                    splittet = content.Replace("https://www.xing.com/", "");

                    return @"\iconhref{Xing}{16}{" + splittet + @"}{" + content + @"}{black}\\[6pt]" + "\n";

                //Linkedin
                case 4:
                    splittet = content.Replace("https://www.linkedin.com/in/", "");
                    return @"\iconhref{Linkedin}{16}{" + splittet + @"}{ " + content + @"}{black}\\[6pt]" + "\n";

                //Homepage
                case 5:
                    splittet = content.Replace("https://www.", "").Replace(".com", "");
                    return @"\iconhref{Home}{16}{" + splittet + @"}{" + content + @"}{black}\\[6pt]" + "\n";

                //Map-Marker
                case 6:
                    return @"\icontext{MapMarker}{16}{" + content + @"}{black}\\[6pt]" + "\n";





                default:
                    return "NV";

            }
        }
        #endregion



        #region RIGHTCOl




        private string LTexMetaBio()
        {
            string ret =
@"\cvsection{Biographie}
\vspace{4pt}

\cvtext{" + $"{Lebenslauf.BiographieViewModel.Biography}" + ".}\n\n";




            return ret;
        }




        private string LTexMetaBeruf()
        {
            string ret = string.Empty;

            foreach (var item in Lebenslauf.Berufserfahrung)
            {

                ret += @"\cvevent" + "\n";
                ret += "{" + item.VonBis + "}\n";
                ret += "{" + item.Beruf + "}\n";
                ret += "{" + item.Arbeitgeber + "}\n";
                ret += "{" + item.Art + item.Kurzbeschreibung + "}\n";
                ret += @"\vfill\null" + "\n";
                ret += @"\vfill\null" + "\n";
            }

            return ret;
        }




        private string LTexMetaEnde()
        {
            string? city = BriefkopfViewModel.Instance.EigenePlzStadt?.Trim().Substring(6);
            string? unterschrift = AnschreibenViewModel.Instance?.SelectedTemplate?.UnterschriftPfad?.Replace('\\', '/');
            string ret = HOTFIX;

            if (string.IsNullOrEmpty(city))
            {
                ret += @"\hrulefill, den \today     \hspace{1cm}   \hrulefill" + "\n" + @"\hspace*{65mm}\phantom{\hrulefill, den \today }";
            }
            else
            {
                if (!string.IsNullOrEmpty(unterschrift))
                {
                    ret += @"\hspace{2.5cm}\phantom{" + city + @", den \today }   \includegraphics {" + unterschrift + "}\n\n";

                }
                ret += city;

                ret += @", den \today     \hspace{1cm}   \hrulefill" + "\n\n" + @"\hspace{2.5cm}\phantom{" + city + @", den \today }" + Lebenslauf.PersonenInfo.Name;

            }


            return ret;
        }


        #endregion
        private void WriteandSave()
        {
            File.WriteAllText(FilePath, LATEX_SETUP + LTexMeta_Person() + LATEX_META_SKILLS_KOMMENTAR + "\n" + LTexMeta_Skills() + LATEX_META_BILDUNG_KOMMENTAR + "\n" + LTexMeta_Bildung() + LTexMeta_Projekte() + LTexMeta_Hobbys() + LTexMeta_Kontakt() + LATEX_END_LEFT_START_RIGHT + LTexMetaBio() + LTEX_WORK_EXP_COMMENT + LTexMetaBeruf() + LTexMetaEnde() + LATEX_END);
        }





    }
}
