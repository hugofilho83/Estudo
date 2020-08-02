CREATE TABLE persons (
  Id bigint(20) NOT NULL AUTO_INCREMENT,
  FirstName varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  LastName varchar(50) COLLATE utf8_unicode_ci DEFAULT NULL,
  Address varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  Gender varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (Id)
) ENGINE=InnoDB