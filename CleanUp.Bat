@Echo Off

attrib -s -h -r

Del *.Ncb
Del *.Opt
Del *.Plg
Del *.Aps
Del *.Scc
Del *.suo
Del *.xml
Del *.old
Del *.user
Del *.sdf

rd IPCH /S /Q

attrib -s -h -r

rd "bin" /S /Q
rd "obj" /S /Q

rd "Setup\Output" /S /Q

Cls
