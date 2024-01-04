

SELECT t.[Index], t.Text, c1.Color ForeColor, c2.Color BackColor
FROM TextObject t
JOIN Color c1 ON t.ForeColor = c1.Id
JOIN Color c2 ON t.BackColor = c2.Id


INSERT INTO TextObject VALUES (7, 'Hei', 4, 5)


SELECT [Index], Text, ForeColor, BackColor, IIF(ForeColor=BackColor,'Likt', 'Ikke') AS Equal, CONCAT(ForeColor, ' ', BackColor)
FROM TextObject
--WHERE [Index] > 4


--SELECT [Index]
--      ,[Text]
--      ,[ForeColor]
--      ,[BackColor]
--  FROM [TextObjects].[dbo].[TextObject]
INSERT INTO TextObject
VALUES (7, 'Hei', 'Blue', 'Pink')
DELETE FROM TextObject
WHERE [Index] = 7UPDATE TextObject
   SET [Index] = 7,
      Text = 'Noe annet',
      ForeColor = 'Blue'
WHERE [Index] = 16




UPDATE TextObject
SET Text = 'Text'


SELECT *
  FROM TextObjectV1


-- DRY  = Don't Repeat Yourself
--SELECT *
--FROM Color

--SELECT *
--FROM TextObject

--SELECT t.[Index], t.Text, c1.Color ForeColor, c2.Color BackColor
--FROM TextObject t
--JOIN Color c1 ON t.ForeColor = c1.Id
--JOIN Color c2 ON t.BackColor = c2.Id

SELECT [Index], Text, ForeColor, Color.*
FROM TextObject
JOIN Color ON TextObject.ForeColor = Color.Id

-- Pause til 13:36