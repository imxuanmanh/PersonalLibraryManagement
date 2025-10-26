-- Thêm dữ liệu cho Author
INSERT INTO Author (Name) VALUES 
('J.K. Rowling'),
('George Orwell'),
('Haruki Murakami'),
('Paulo Coelho'),
('Nguyễn Nhật Ánh'),
('Nam Cao'),
('Tô Hoài'),
('Ernest Hemingway'),
('Jane Austen'),
('Agatha Christie');

-- Thêm dữ liệu cho Category
INSERT INTO Category (Name) VALUES 
('Tiểu thuyết'),
('Truyện ngắn'),
('Thơ'),
('Thiếu nhi'),
('Khoa học viễn tưởng'),
('Trinh thám'),
('Kinh dị'),
('Lãng mạn'),
('Tâm lý - Kỹ năng sống'),
('Lịch sử');


-- Thêm dữ liệu cho Publisher
INSERT INTO Publisher (Name) VALUES 
('NXB Trẻ'),
('NXB Kim Đồng'),
('NXB Văn Học'),
('NXB Lao Động'),
('NXB Hội Nhà Văn');


-- Thêm dữ liệu cho Room
INSERT INTO Room (Name) VALUES 
('Phòng khách'),
('Phòng ngủ'),
('Phòng làm việc'),
('Phòng học'),
('Phòng sách');

-- Thêm dữ liệu cho Shelf
INSERT INTO Shelf (RoomId, Ordinal) VALUES
(1, 1), (1, 2),
(2, 1), (2, 2), (2, 3),
(3, 1);

SELECT * from Book;
SELECT * FROM Author;
SELECT * FROM Category;
SELECT * FROM Publisher;

UPDATE sqlite_sequence SET seq = 0 WHERE name='Book';
UPDATE sqlite_sequence SET seq = 0 WHERE name='Circulation';

SELECT * FROM Circulation;

DELETE FROM Book;
DELETE FROM Circulation;

INSERT INTO Book (Title, AuthorId, CategoryId, PublisherId, PublishYear, Description, StorageLocationId, ImagePath)
VALUES
('Harry Potter and the Philosopher''s Stone', 1, 1, 2, 1997,
 'Harry Potter, một cậu bé mồ côi sống cùng gia đình Dursley, bất ngờ phát hiện ra mình là một phù thủy. Khi được mời đến Hogwarts, cậu bước vào một thế giới phép thuật đầy màu sắc, nơi các lớp học kỳ diệu, những sinh vật huyền bí và tình bạn chân thành chờ đón. Nhưng phía sau lớp màn kỳ diệu, một bóng tối từ quá khứ đang rình rập, đe dọa cậu và những người bạn mới.',
 3, 'harry-potter-and-the-philosophers-stone.png'),

('Harry Potter and the Chamber of Secrets', 1, 1, 2, 1998,
 'Trở lại Hogwarts, Harry phát hiện những bí ẩn đen tối đang thức tỉnh. Những tiếng thì thầm bí ẩn, học sinh bị hóa đá, và một căn phòng cổ xưa được mở ra khiến cả trường náo loạn. Cùng Ron và Hermione, Harry phải đối mặt với những mối nguy hiểm chưa từng thấy, hé lộ những bí mật sâu kín của trường và dòng dõi phù thủy.',
 3, 'harry-potter-and-the-chamber-of-secrets.png'),

('Harry Potter and the Prisoner of Azkaban', 1, 1, 2, 1999,
 'Một kẻ đào ngục nguy hiểm thoát khỏi Azkaban, và Harry trở thành mục tiêu. Quá khứ của cha mẹ cậu, những bí ẩn về người thân và những sinh vật huyền bí lần lượt xuất hiện. Trong hành trình tìm kiếm sự thật, Harry học được sức mạnh của tình bạn, lòng can đảm và nhận ra rằng không phải mọi bí mật đều mang lại sự an toàn.',
 3, 'harry-potter-and-the-prisoner-of-azkaban.png'),

('Harry Potter and the Goblet of Fire', 1, 1, 2, 2000,
 'Harry bất ngờ được chọn tham gia Giải đấu Tam Pháp thuật – nơi các thí sinh phải đối mặt với những thử thách sinh tử. Qua mỗi vòng thi, cậu phải chiến đấu với nguy hiểm, nỗi sợ hãi và những âm mưu đen tối. Kết thúc giải đấu mở ra một bước ngoặt lớn, thay đổi hoàn toàn thế giới phép thuật mà Harry từng biết.',
 3, 'harry-potter-and-the-goblet-of-fire.png'),

('Harry Potter and the Order of the Phoenix', 1, 1, 2, 2003,
 'Thế giới phù thủy rối ren khi Voldemort trở lại nhưng không được tin tưởng. Harry phải tự mình chiến đấu với sự cô lập, hiểu lầm và nỗi thất vọng. Trong bối cảnh đó, Hội Phượng Hoàng được tái lập, chuẩn bị cho cuộc chiến lớn sắp đến. Harry phải đối diện với nỗi sợ, sự mất mát và sức mạnh tiềm ẩn trong chính mình.',
 3, 'harry-potter-and-the-order-of-the-phoenix.png'),

('Harry Potter and the Half-Blood Prince', 1, 1, 2, 2005,
 'Chiến tranh lan rộng, Hogwarts chìm trong bầu không khí căng thẳng. Dumbledore dẫn dắt Harry khám phá những bí mật sâu kín về Voldemort, quá khứ đau lòng và những lựa chọn đầy khó khăn. Một cuốn sách cổ chứa những chú giải kỳ lạ hé lộ manh mối quan trọng, và Harry nhận ra rằng tình bạn và sự hy sinh sẽ là chìa khóa quyết định mọi kết cục.',
 3, 'harry-potter-and-the-half-blood-prince.png'),

('Harry Potter and the Deathly Hallows', 1, 1, 2, 2007,
 'Harry, Ron và Hermione bắt đầu hành trình cuối cùng để tiêu diệt Voldemort, không còn nơi nào an toàn. Họ đối mặt với những trận chiến cam go, mất mát và những lựa chọn sinh tử. Trong cuộc đấu tranh giữa ánh sáng và bóng tối, tình bạn, lòng dũng cảm và hy sinh được thử thách đến giới hạn cuối cùng, khép lại một chương huyền thoại của thế giới phù thủy.',
 3, 'harry-potter-and-the-deathly-hallows.png');
 
 
 -- Giả sử Author Nguyễn Nhật Ánh đã có Id = 1
-- CategoryId, PublisherId, StorageLocationId giả sử đều là 1 (bạn chỉnh theo DB thực tế)

INSERT INTO Book (Title, AuthorId, CategoryId, PublisherId, PublishYear, Description, StorageLocationId, ImagePath)
VALUES 
('Cho tôi xin một vé đi tuổi thơ', 5, 2, 1, 2002, 
'Một câu chuyện ngọt ngào và sâu lắng về tuổi thơ, những trò nghịch ngợm tinh nghịch, tình bạn giản dị và bài học đầu đời về gia đình và lòng dũng cảm.', 1, 'cho-toi-xin-mot-ve-di-tuoi-tho.png'),

('Mắt biếc', 5, 2, 1, 1990, 
'Câu chuyện về tình yêu đầu đời, những rung động tinh khôi và nỗi tiếc nuối khôn nguôi, qua nhân vật Ngạn và cô bạn học Trà My.', 1, 'mat-biec.jpg'),

('Ngồi khóc trên cây', 5, 2, 1, 1991, 
'Câu chuyện về những tâm tư, nỗi cô đơn và ước mơ của tuổi học trò, nhân vật chính đối mặt với thử thách và tìm kiếm tình bạn đích thực.', 1, 'ngoi-khoc-tren-cay.png'),

('Cô gái đến từ hôm qua', 5, 2, 1, 1989, 
'Một bức tranh về tuổi thanh xuân với những rung động tinh khôi, những bí mật và kỷ niệm khó quên, đưa người đọc trở lại thời học trò trong sáng.', 1, 'co-gai-den-tu-hom-qua.png'),

('Bồ câu không đưa thư', 5, 2, 1, 1992, 
'Câu chuyện lãng mạn pha chút hài hước về những mối quan hệ ngây ngô nhưng chân thành, mang góc nhìn giản dị về cuộc sống, tình cảm và ước mơ.', 1, 'bo-cau-khong-dua-thu.png');

UPDATE Book
SET ImagePath = 'mat-biec.png'
WHERE Id = 9;
