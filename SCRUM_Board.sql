/*CREATE TABLE tblStory(
	StoryID	INT	IDENTITY(1,1) NOT NULL,
	Nooftasks INT,
	Name VARCHAR(20) NOT NULL,
	Department VARCHAR(20) NOT NULL,
	Description VARCHAR(150) NOT NULL,
	Status VARCHAR(20) NOT NULL
)*/

-- DROP TABLE tblStory;

/*
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
*/
/*
Create procedure spUpdateStory(
	@StoryID INT,
	@NoofTasks INT,
	@Description VARCHAR(150),
	@Status VARCHAR(20)
)
as
begin
	Update tblStory
	set Nooftasks = @NoofTasks,
	Description = @Description,
	Status = @Status
	where StoryID = @StoryID
end
*/
/*
Create procedure spDeleteStory(
	@StoryID int
)
as
begin
	Delete from tblStory where StoryID = @StoryID
end
*/
/*
Create Procedure spGetAllStories
as
	begin
		select *
		from tblStory
end
*/


