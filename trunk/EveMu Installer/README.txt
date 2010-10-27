EveMu Server Installer

##############################################
#					     #
#            Version: 0.1 Beta               #
#             Author: Graham "H|X|N" Hickson #
# Last ReadMe Update: 27/10/2010	     #
#					     #
# Credits:				     #
#	AknorJordan (Sparked The Idea)	     #
#					     #
##############################################

Installer Usage:

	Simply run EveMu Installer.exe and either accept defaults or provide your own.

Repository Setup:

	If you want to run a repository the here is the setup you will need.

Requirements:
		
	Web Server

Folder Structure:

		[root directory]
		|-------[versions]
		|	\-------*.zip
		\-------versions.xml

versions Directory Explained:
		
	The versions directory contains all packages in *.zip format.

	Each zip package requires the following directory structure:

			[package.zip]
			|-------[bin]
			|	\-------eve-server.exe
			\-------[etc]

	This is so the installer can unzip and relocate the files ready for configuration easily.


versions.xml File Explained:

	The versions.xml file is used by the installer to determine what packages are available and 
	some basic information about them.

	The versions.xml format is as follows:

		<Versions>
			<Version id="0" name="Sample Version name" arch="x86" rev="974" filename="s974_x86.zip" ?>
			<Version id="1" name="Sample Version name" arch="x64" rev="974" filename="s974_x64.zip" ?>
			<Version id="2" name="Sample Version name" arch="x86" rev="975" filename="s974_x86.zip" ?>
			<Version id="3" name="Sample Version name" arch="x64" rev="975" filename="s974_x64.zip" ?>
		</Versions>

	Basic but effective I think.