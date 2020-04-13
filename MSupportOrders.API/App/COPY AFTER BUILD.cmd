set loc=W:\REPO\MSupportOrders\MSupportOrders.API\App\
chdir /d %loc%
CD templates
COPY *.html W:\REPO\MSupportOrders\MSupportOrders.API\_publish\scripts\templates\
CD ..
CD views
COPY *.html W:\REPO\MSupportOrders\MSupportOrders.API\_publish\scripts\views\