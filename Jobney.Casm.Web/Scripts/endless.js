
$(function	()	{
	//Skin color
	$('.theme-color').click(function()	{
		//Cookies for storing theme color
		$.cookie('skin_color', $(this).attr('id'));
		
		$('aside').removeClass('skin-1');
		$('aside').removeClass('skin-2');
		$('aside').removeClass('skin-3');
		$('aside').removeClass('skin-4');
		$('#top-nav').removeClass('skin-1');
		$('#top-nav').removeClass('skin-2');
		$('#top-nav').removeClass('skin-3');
		$('#top-nav').removeClass('skin-4');
		
		$('aside').addClass($(this).attr('id'));
		$('#top-nav').addClass($(this).attr('id'));
	});
	
	//Submenu
	$('aside li').hover(
       function(){ $(this).addClass('open') },
       function(){ $(this).removeClass('open') }
	)

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
       function(){ $(this).addClass('open') },
       function(){ $(this).removeClass('open') }
	)

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
	$('#wrapper').removeAttr('class');
});