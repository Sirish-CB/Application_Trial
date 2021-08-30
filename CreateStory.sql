CREATE procedure spAddStory(
	@StoryID INT,
	@Nooftasks INT,
	@Name VARCHAR(20),
	@Department VARCHAR(20),
	@Description VARCHAR(150),
	@Status VARCHAR(20)
)
as
Begin
	Insert into tblStory(StoryID, Nooftasks, Name, Department, Description, Status)
	Values (@StoryID, @Nooftasks, @Name, @Department, @Description, @Status)
End 
