$(function(){
	$('.dragbox')
	.each(function(){
		$(this).click(function(){
			$(this).siblings('.dragbox-content').toggle();
		})
		.end()
	});
	$('.column').sortable({
		connectWith: '.column',
		handle: 'h2',
		cursor: 'move',
		placeholder: 'placeholder',
		forcePlaceholderSize: true,
		opacity: 0.4,
		stop: function(event, ui){
			$(ui.item).find('h2').click();
			var sortorder='';
			$('.column').each(function(){
				var itemorder=$(this).sortable('toArray');
				var columnId=$(this).attr('id');
				sortorder+=columnId+'='+itemorder.toString()+'&';
			});
			alert('SortOrder: '+sortorder);
			/*Pass sortorder variable to server using ajax to save state*/
		}
	})
	.disableSelection();
});