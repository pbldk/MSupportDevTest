set loc=W:\REPO\MSupportDevTest\MSupportOrders.API\App\
chdir /d %loc%
CD templates
COPY *.html W:\REPO\MSupportDevTest\MSupportOrders.API\_publish\scripts\templates\
CD ..
CD views
COPY *.html W:\REPO\MSupportDevTest\MSupportOrders.API\_publish\scripts\views\