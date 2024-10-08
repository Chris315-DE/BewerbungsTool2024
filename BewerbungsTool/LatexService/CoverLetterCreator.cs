﻿using BewerbungsTool.Model;
using BewerbungsTool.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BewerbungsTool.LatexService
{
    public class CoverLetterCreator
    {
        AnschreibenTemplate SelectedAnschreibenTemplate { get; set; }
        BriefkopfViewModel Briefkopf { get; set; }
        string SavePath;
        string FilePath;
        public CoverLetterCreator(AnschreibenTemplate anschreiben)
        {
            SelectedAnschreibenTemplate = anschreiben;
            Briefkopf = BriefkopfViewModel.Instance;
            SavePath = Path.Combine(AppContext.BaseDirectory, "Bewerbung");


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



            FilePath = Path.Combine(SavePath, $"cover_letter{countfiles}.tex");


            InitBriefkopfEigeneAdresse();
            InitBriefkopfFirmaAdresse();
            AnschreibenTextGen();

            WriteAndSafe();

        }

        #region LatexInit
        private string initLatexSetup = @"%-----------------------------------------------------------------------------------------------------------------------------------------------%
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

%we use article class because we want to fully customize the page and don't use a cv template
\documentclass[10pt,A4,german]{article}	


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
\usepackage[german]{babel}
\usepackage{lipsum}
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
\node[yshift=0.32cm,xshift=9cm] at (current page.south) {\fontsize{10}{10}\selectfont \setcounter{page}{#1}
 \textbf{}};
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

\setlength{\columnsep}{2.2em}
\setlength{\columnseprule}{4pt}
\colseprulecolor{white}

\AtBeginShipoutFirst{\Header{Anschreiben}\Footer{1}}
\newpage

%%%%ANSCHREIBEN";

        #endregion

        #region BriefkopfStrings

        private string EigenAdresseBriefkopf;

        private string EigeneAdresseLatexCommand = @"} \\
& & \cvtext{";


        private string EigeneAdresseBriefkopf1 = @"\cvtext{}\\[10pt]
\begin{tabular}[t]{p{5cm}p{9cm}p{6cm}}
& & \cvtext{\textbf{";

        private string EigeneAdresseLatexEndeCommand = @"}\\[20pt]
    \end{tabular}\\";
        #endregion

        #region FirmaBriefkopfStrings

        string FirmaLatexStart = @"\cvtext{\textbf{";
        string FirmaLatex1 = @"\newline ";
        string FirmaLatex2 = @"\\[40pt]
\raggedright
\begin{tabular}[t]{p{5cm}p{6.8cm}p{8cm}}
& & \cvtext{";
        string FirmaLatex3 = @", den \today}\\[20pt]
\end{tabular}";
        string GesammtLatexFirmaBriefkopf;
        private void InitBriefkopfFirmaAdresse()
        {
            string zuhänden;
            if (!string.IsNullOrEmpty(Briefkopf.FirmaPerson))
            {
                zuhänden = Briefkopf.FirmaZuHänden + @" \newline " + Briefkopf.FirmaPerson + " ";
            }
            else
            {
                zuhänden = "Personalabteilung";
            }


            GesammtLatexFirmaBriefkopf = FirmaLatexStart + Briefkopf.FirmaName.Replace("/r", "") + "\n"
               + "}" + FirmaLatex1 + zuhänden + FirmaLatex1 + Briefkopf.FirmaStraße.Replace("\r", string.Empty) + FirmaLatex1 +
               Briefkopf.FirmaPlzStadt.Replace("/r", string.Empty) + "}"
               + FirmaLatex2 + Briefkopf.EigenePlzStadt.Substring(5) + FirmaLatex3;
        }


        #endregion


        #region AnschreibenText

        private string Anschreibentext;

        private void AnschreibenTextGen()
        {
            string latex1 = @"\cvtext{\large{\textbf{" + SelectedAnschreibenTemplate.Headder + @"}}}\\[50pt]";
            string latex2 = @"\cvtext{" + Briefkopf.AnredeVorschau + @",\newline \newline}\\[40pt]";
            string latex3 = @"\cvtext{" + SelectedAnschreibenTemplate.Einleitung + @" \newline \newline \newline ";
            string latex4 = "\n" + SelectedAnschreibenTemplate.Hauptteil + @"}\\[25pt]";
            string latex5 = @"\cvtext{" + SelectedAnschreibenTemplate.StartDatumSatz + @" \newline ";

            if (!string.IsNullOrEmpty(SelectedAnschreibenTemplate.BruttoGehaltSatz))
            {
                latex5 += SelectedAnschreibenTemplate.BruttoGehaltSatz + @". \newline ";
            }


            latex5 += SelectedAnschreibenTemplate.Abschluss + @"}\\[100pt]";


            string latex6 = @"Mit freundlichen Grüßen, \newline ";

            string latex7 = @"\includegraphics {" + SelectedAnschreibenTemplate.UnterschriftPfad.Replace('\\','/') + 
                @"} \newline \cvtext{" + Briefkopf.EigeneName + "}" ;

         //\includegraphics[width =\linewidth]{ .. / resources / image.jpg}

            Anschreibentext = latex1 + latex2 + latex3 + latex4 + latex5 + latex6 + latex7;

        }


        #endregion


        private void WriteAndSafe()
        {
            File.WriteAllText(FilePath, initLatexSetup + EigenAdresseBriefkopf + GesammtLatexFirmaBriefkopf + Anschreibentext + @"\end{document}");
        }
        private void InitBriefkopfEigeneAdresse()
        {
            EigenAdresseBriefkopf = EigeneAdresseBriefkopf1 +
            Briefkopf.EigeneName.Replace("\r", string.Empty) + "}" + EigeneAdresseLatexCommand + Briefkopf.EigeneStraße.Replace("\r", string.Empty) +
            EigeneAdresseLatexCommand + Briefkopf.EigenePlzStadt.Replace("\r", string.Empty) + EigeneAdresseLatexCommand +
            Briefkopf.EigeneTel.Replace("\r", string.Empty) + EigeneAdresseLatexCommand + Briefkopf.EigeneMail.Replace("\r", string.Empty) + EigeneAdresseLatexEndeCommand;
        }



    }
}
