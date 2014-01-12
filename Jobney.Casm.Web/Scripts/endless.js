$(function	()	{
    //Submenu
    $('aside li').hover(
        function() { $(this).addClass('open'); },
        function() { $(this).removeClass('open'); }
    );

	//Toggle Menu
	$('#sidebarToggle').click(function()	{
		$('#wrapper').toggleClass('sidebar-display');
	});
	
	$('#sizeToggle').click(function()	{
		$('#wrapper').toggleClass('sidebar-mini');
	});

	//Hover effect on touch device
	$('.image-wrapper').bind('touchstart', function(e) {
		$('.image-wrapper').removeClass('active');
		$(this).addClass('active');
    });
	
	//Dropdown menu with hover
    $('.hover-dropdown').hover(
        function() { $(this).addClass('open'); },
        function() { $(this).removeClass('open'); }
    );

	// Popover
    $("[data-toggle=popover]").popover();
	
	// Tooltip
    $("[data-toggle=tooltip]").tooltip();
	
});

$(window).load(function() {
	
	// Fade out the overlay div
	$('#overlay').fadeOut(800);
	
	$('body').removeAttr('class');
	$('body').removeAttr('style');

	//Enable animation
	$('#wrapper').removeClass('preload');

	$('.main-menu>ul>li').removeClass('active');

	$('.main-menu>ul>li>a').filter(function (i, e) {
	    return e.href == document.location.protocol + '//' + document.location.host + document.location.pathname
	}).closest('li').addClass('active')
});