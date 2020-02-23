 -- OVO SAM SOLO PROBAO, RADI UPIT
 SELECT IdSeminar, count(IdSeminar) as total FROM Predbiljezba
        where Status='Prihvaæeno' GROUP BY IdSeminar ORDER BY total DESC
 
 
 
 
 
  BEgin tran
  
  update sm 
   set sm.BrojPredbiljezbi = (select count(*) from Predbiljezba prb where prb.IdSeminar = sm.IdSeminar and prb.Status = 'Prihvaæeno' )
   from Seminar sm
   where sm.IdSeminar = 3;
   


     select * From Predbiljezba where IdSeminar = 3;


   select * From Seminar where IdSeminar = 3;

update sm set sm.BrojPredbiljezbi = (select count(*) from Predbiljezba prb where prb.IdSeminar = sm.IdSeminar and prb.Status = 'Prihvaæeno') from Seminar sm where sm.IdSeminar =3


rollback



  SELECT count(prb.Status), 
  FROM Seminar sm
  inner join Predbiljezba prb on prb.IdSeminar = sm.IdSeminar
  where prb.Status = 'Prihvaæeno';

  SELECT count(prb.Status) as num_of_prihvaceno, prb.IdSeminar
  FROM Predbiljezba prb
  where prb.Status = 'Prihvaæeno'
  group by prb.IdSeminar;


  UPDATE Predbiljezba 
   SET status='Prihvaæeno' ,
   BrojPredbiljezbi = BrojPredbiljezbi + 1
   WHERE idPredbiljezba=@ID


   select * From Predbiljezba where IdSeminar = 1;


   select * From Seminar where IdSeminar = 1;

   rollback
   update Seminar  
   set BrojPredbiljezbi = (select count(*) from Predbiljezba prb where prb.IdSeminar = IdSeminar )


  select 
	  sm.IdSeminar,
	  sm.Naziv,
	  sm.opis,
	  sm.Datum,
	  sm.BrojPredbiljezbi,
	  sm.MaxBrojPredbiljezbi,
	  sm.Status,
	  (select count(prb.Status)  FROM Predbiljezba prb where prb.IdSeminar = sm.IdSeminar and prb.Status = 'Prihvaæeno') as num_of_prh
  from Seminar sm
    -- left join Predbiljezba prb on prb.IdSeminar = sm.IdSeminar
--where prb.Status = 'Prihvaæeno'