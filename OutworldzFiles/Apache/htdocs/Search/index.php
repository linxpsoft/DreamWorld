<html lang="en-us">
<!-- AGPL 3.0 by Fred Beckhusen -->
<head>
<meta charset="utf-8">
<title>Opensimular search</title>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script type="text/javascript"  src="/flexgrid/js/flexigrid.js"></script>
<link rel="stylesheet" type="text/css" href="style.css">

<script type="text/javascript">
$(document).ready(function(){
	
	$("a").click(function(){
		top.window.location.href=$(this).attr("href");
		$("#playing").html( '<p>&nbsp;Opening...</p>' );
		return true;
	})
	
	$("#flex1").flexigrid({
		url: '/Search/search_json.php',
		dataType: 'json',
        method: 'GET',
		colModel : [
			{display: 'Hop', name : 'hop', width : 35, sortable : false, align: 'left'},		
			{display: 'Name', name : 'Name', width : 140, sortable : true, align: 'left'},			
			{display: 'Description', name : 'Description', width : 160, sortable : true, align: 'left'},			
			{display: 'Region name', name : 'Regionname', width :125, sortable : true, align: 'left'},
			{display: 'Location', name : 'Location', width : 190, sortable : true, align: 'left'}
			],
		
		searchitems : [
		 {display: 'Name', name :'Name', isdefault: true},
		 {display: 'Description', name :'Description', isdefault: false}
		 
		],
		sortname: 'Name',
		sortorder: 'asc',
		usepager: true,
		title: 'Click header to sort. Search button is at the bottom left.',
		useRp: true,
		rp: 100,
		showTableToggleBtn: false,
		width: 700,
		height: 400
	});


	$(document).on("click", ".hop", function(event){
		event.preventDefault();
		$("#playing").html( '<p>&nbsp;Teleporting...</p>' );
		var url = $(this).attr('href');
		window.location.href = url;
    });

});

</script>

<link rel="stylesheet" type="text/css" media="all" href="/flexgrid/css/flexigrid.css" />

<link rel="shortcut icon" href="/favicon.ico">

</head>

<body>
<div id="Links">
<a href="index.php"><button>Objects</button></a>
<!--<a href="SearchClassifieds.php"><button>Classifieds</button></a>-->
<a href="SearchParcel.htm"><button>Parcels</button></a>
<a href="SearchHosts.htm"><button>Grids</button></a>
<a href="SearchRegions.htm"><button>Regions</button></a>
<button onclick="location.reload();">Refresh Page</button>
</div>
<div id="greet">
    <div id="playing"></div>
    <div id="flex1" ></div>	
</div>

</body>

</html>