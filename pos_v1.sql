-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 21, 2023 at 10:09 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pos_v1`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `ACCOUNT_USERNAME` varchar(50) NOT NULL,
  `ACCOUNT_PASSWORD` varchar(50) NOT NULL,
  `ACCOUNT_STATUS` varchar(50) NOT NULL,
  `ACCOUNT_USERTYPE` varchar(50) NOT NULL,
  `ACCOUNT_FULL_NAME` varchar(50) NOT NULL,
  `ACCOUNT_CONTACT_NUMBER` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`ACCOUNT_USERNAME`, `ACCOUNT_PASSWORD`, `ACCOUNT_STATUS`, `ACCOUNT_USERTYPE`, `ACCOUNT_FULL_NAME`, `ACCOUNT_CONTACT_NUMBER`) VALUES
('admin', 'admin', 'ACTIVE', 'MANAGER', 'john henrick orejudos', '09192122534'),
('tech', 'tech', 'ACTIVE', 'USER', 'mj orejudos', '0912122163'),
('user12', '123456', 'ACTIVE', 'USER', 'xian valdez', '+6309094982121');

-- --------------------------------------------------------

--
-- Table structure for table `logs`
--

CREATE TABLE `logs` (
  `timelog` varchar(50) NOT NULL,
  `datelog` varchar(50) NOT NULL,
  `full_name` varchar(60) NOT NULL,
  `action` varchar(250) NOT NULL,
  `module` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Dumping data for table `logs`
--

INSERT INTO `logs` (`timelog`, `datelog`, `full_name`, `action`, `module`) VALUES
('23:44:16', '', 'john henrick orejudos', 'Updated Existing Account ID:user1 by: john henrick orejudos', 'Account'),
('23:47:19', '2023-02-14', 'john henrick orejudos', 'Updated Existing Account ID:user by: john henrick orejudos', 'Account'),
('00:33:51', '2023-02-15', 'john henrick orejudos', 'Added New Account :user12 by: john henrick orejudos', 'Account'),
('00:36:53', '2023-02-15', 'john henrick orejudos', 'Added New Account :user123 by: john henrick orejudos', 'Account'),
('14:49:12', '2023-02-16', 'john henrick orejudos', 'Update Account :michelle by: john henrick orejudos', 'Account'),
('14:50:22', '2023-02-16', 'john henrick orejudos', 'Update Account :Michelle by: john henrick orejudos', 'Account'),
('14:51:59', '2023-02-16', 'john henrick orejudos', 'Update Account :Michelle by: john henrick orejudos', 'Account'),
('15:07:54', '2023-02-16', 'john henrick orejudos', 'Update Account :michelle serrano by: john henrick orejudos', 'Account'),
('15:14:47', '2023-02-16', 'john henrick orejudos', 'Update Account :michelle  serrano by: john henrick orejudos', 'Account'),
('15:19:33', '2023-02-16', 'john henrick orejudos', 'Added New Account :dasdsa by: john henrick orejudos', 'Account'),
('15:19:32', '2023-02-16', 'john henrick orejudos', 'Updated Existing Account ID:dasdsa by: john henrick orejudos', 'Account'),
('16:17:53', '2023-02-16', 'john henrick orejudos', 'Updated Existing Account ID:user123 by: john henrick orejudos', 'Account'),
('23:10:36', '2023-02-16', 'john henrick orejudos', 'Added New Item ID:123123 by: john henrick orejudos', 'Account'),
('23:12:52', '2023-02-16', 'john henrick orejudos', 'Added New Item ID:dsadas by: john henrick orejudos', 'Account'),
('23:18:48', '2023-02-16', 'john henrick orejudos', 'Added New Item ID:asd by: john henrick orejudos', 'Account'),
('23:20:43', '2023-02-16', 'john henrick orejudos', 'Added New Item ID:dsada by: john henrick orejudos', 'Account'),
('09:11:40', '2023-02-17', 'john henrick orejudos', 'Added New Item ID:2313131 by: john henrick orejudos', 'Account'),
('13:20:00', '2023-02-17', 'john henrick orejudos', 'Added New Item ID:aaaaa by: john henrick orejudos', 'Account'),
('13:24:28', '2023-02-17', 'john henrick orejudos', 'Added New Item ID:aadaadd by: john henrick orejudos', 'Account'),
('13:28:30', '2023-02-17', 'john henrick orejudos', 'Added New Item ID:fdadsa by: john henrick orejudos', 'Account'),
('15:15:24', '2023-02-17', 'john henrick orejudos', 'Added New Item ID:admdsa by: john henrick orejudos', 'Account'),
('18:23:20', '2023-02-17', 'john henrick orejudos', 'Added New Item ID:adasddas by: john henrick orejudos', 'Account'),
('16:43:29', '2023-02-18', 'john henrick orejudos', 'Added New Item ID:adfa by: john henrick orejudos', 'Account'),
('16:44:46', '2023-02-18', 'john henrick orejudos', 'Added New Item ID:asdaads by: john henrick orejudos', 'Account'),
('18:48:36', '2023-02-18', 'john henrick orejudos', 'Added New Item ID:xczxc by: john henrick orejudos', 'Account'),
('12:22:31', '2023-02-19', 'john henrick orejudos', 'Added New Item ID:saddas by: john henrick orejudos', 'Account'),
('09:51:13', '2023-02-20', 'john henrick orejudos', 'Added New Item ID:1231321 by: john henrick orejudos', 'Account'),
('13:56:29', '2023-02-20', 'john henrick orejudos', 'Updated Existing Account ID:System.Drawing.Bitmap by: john henrick orejudos', 'Account'),
('13:56:41', '2023-02-20', 'john henrick orejudos', 'Updated Existing Account ID:System.Drawing.Bitmap by: john henrick orejudos', 'Account'),
('13:56:41', '2023-02-20', 'john henrick orejudos', 'Updated Existing Account ID:System.Drawing.Bitmap by: john henrick orejudos', 'Account'),
('13:57:01', '2023-02-20', 'john henrick orejudos', 'Updated Existing Account ID:System.Drawing.Bitmap by: john henrick orejudos', 'Account'),
('13:58:04', '2023-02-20', 'john henrick orejudos', 'Updated Existing Account ID:System.Drawing.Bitmap by: john henrick orejudos', 'Account'),
('14:02:15', '2023-02-20', 'john henrick orejudos', 'Updated Existing Account ID:System.Drawing.Bitmap by: john henrick orejudos', 'Account'),
('14:02:24', '2023-02-20', 'john henrick orejudos', 'Added New Account :user321 by: john henrick orejudos', 'Account'),
('14:03:40', '2023-02-20', 'john henrick orejudos', 'Updated Existing Account ID:System.Drawing.Bitmap by: john henrick orejudos', 'Account'),
('14:24:07', '2023-02-20', 'john henrick orejudos', 'Updated Existing Account ID:user321 by: john henrick orejudos', 'Account'),
('16:28:55', '2023-02-20', 'john henrick orejudos', 'Added New Item ID:sadasd by: john henrick orejudos', 'Account'),
('16:44:33', '2023-02-20', 'john henrick orejudos', 'Added New Item ID:adaxcaz by: john henrick orejudos', 'Account'),
('19:04:11', '2023-02-20', 'john henrick orejudos', 'Added New Item ID:adaxcaz by: john henrick orejudos', 'products'),
('19:04:19', '2023-02-20', 'john henrick orejudos', 'Added New Item ID:xcxzczx by: john henrick orejudos', 'products'),
('19:04:27', '2023-02-20', 'john henrick orejudos', 'Added New Item ID:adaxcaz by: john henrick orejudos', 'products'),
('19:04:36', '2023-02-20', 'john henrick orejudos', 'Added New Item ID:adaxcaz by: john henrick orejudos', 'products'),
('13:04:39', '2023-02-21', 'john henrick orejudos', 'Added New Item ID:3211231 by: john henrick orejudos', 'Products');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `PRODUCT_ID` varchar(50) NOT NULL,
  `PRODUCT_NAME` varchar(50) NOT NULL,
  `PRODUCT_PRICE` varchar(50) NOT NULL,
  `PRODUCT_DESCRIPTION` varchar(200) NOT NULL,
  `PRODUCT_STATUS` varchar(30) NOT NULL,
  `PRODUCT_CATEGORY` varchar(50) NOT NULL,
  `PRODUCT_AVAILABILITY` varchar(30) NOT NULL,
  `PRODUCT_IMAGE` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`PRODUCT_ID`, `PRODUCT_NAME`, `PRODUCT_PRICE`, `PRODUCT_DESCRIPTION`, `PRODUCT_STATUS`, `PRODUCT_CATEGORY`, `PRODUCT_AVAILABILITY`, `PRODUCT_IMAGE`) VALUES
('1231321', 'americano', '50', 'adasdadaasdasdasasdasdasdas', 'In-Stock', 'REFRESHERS', 'AVAILABLE', 0xffd8ffe000104a46494600010101004800480000ffe100c64578696600004d4d002a000000080007013200020000001400000062013e00050000000200000076013f000500000006000000860301000500000001000000b6511000010000000101000000511100040000000100000b13511200040000000100000b1300000000323032333a30323a30372031353a33343a35340000007a25000186a000008083000186a00000f9ff000186a0000080e9000186a000007530000186a00000ea60000186a000003a98000186a00000176f000186a0000186a00000b18effdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc00011080064006403012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00f9fe8a28a0028a28a0028a28a0028a28a0028a28a0028a28a0028a28a0028a28a0028a28a0028adeff008427c599c7fc22fad7fe004bff00c4d34f833c543af86b591ff6e12fff001340187456dffc21be28ff00a16f58ff00c0197ff89a78f0478b59772f85f5b23d469f2fff001340183456f7fc20fe2dce3fe116d6ff00f05f2fff001354f51f0eeb7a44027d4f46d42ca267d824b9b578d4b609c6580e7009c7b50066d1451400514514005145140056ff0081467e20f8687fd456d7ff0046ad6056df836786d7c73e1fb8b89638618b52b679249182aa289549249e0003bd007da72ec8e720a16f940dc0f26a1921b5237169c7b06ac57f1ae910ac1f6fb98e0b96894ca8b96556c6480c40247be07d05489e32f0fdc3ec4bc8ddb19c0359dcd2c49344be61f2e6b800f4cb0ff0a7ac971143b05cc98f723fc2b0aebc71e1c8a660750897071cb74a6c9e3ef092c597d521cfaab8e6a5486d1b62e6e7cd5ff4890e3d48ae17e28786ef3c5ba0dad9dbdcc29722f1640f725f6ed11be46555b1cb77c0fc48ce849f117c208f91ab2b63fbaa5bf95177f103c3f6ba049abcf3cf15b2b054fdcb132b90e55571dc88dbae00e3279aa4ee4b564788ea1f087c4f6568f3dbfd9350643f34366ee5f1b4b12032aeee074049248001e71c157d59a0f8af4af12411dc5a348d0c9b7e665c1463fc248e03023919cf43d1949f26f8e3e1c8b49f1158eab6f043047a9c4e6454c82f3237cce463032ae9d3a90c4f3c9b4c968f2ca28a298828a2b613c29e239227953c3faab468ccaceb67210a5495604e3820820fa1068031e8aedf4ff84be30bfba861fb0450c736f0b3bdc23a657391fbb2c49c8dbc0383d71ce3a297e1f787fc3fb4df2dd6a92223976171e544df36d0c11509f941071e672463201e136914a2d97fc7b77124b1de6635864198d924122ba670ac187041183c6473d4f53c68d4226042c8a79f5a87c5babdadd241676915cc50dae638a29aecce123fe15563d00f41c73c62b972cb8e58eecf38aa4c968d9bb9833b608359ccfcd53def8ddb8f5f5a3ce6cfe14981a567f35c203d33ce2ba8f88c60874bf0ed8ec31dd430c923a924ee8df6147e800c90e3193f773df1591e12d364d5358b6b75524b365b8ce00ea7f2aeff0055f07d878bbc536d2fdb534fd2608c43e4aa8f3ffd7333f7c60ef760f807900c79cd49562afc0fd3a7babad4a492d50d90d8c93bc4e4899723e47c6c042c8d904eef9971c6ead4fda22e227ff8466d84b199a24b8678c302c15bcbdac4750095603d769f4af50f08e83a668da3c563a5c0d1dac78f9cafcd2b91f33b1fe2627e8318000000af9e7e2cf8a2d3c53e3679ac9736f6508b259838613ec7725d7191b49638e4e4007be00b5627b1c2d14515423d8be12f85ed6c6ce3f176a4ecb2b974b052e026de519ce1b3c9122608c0c13ce411734ef172ddf8865d48451c70cd2012b0b750f385e8376391dbf9571965e3bb58bc156be1f9edae53c88a48ccb09196ccad20ebd01dec08edb41c9dc42f59a95b59e93a0c02c64b7babcb663124eb8298ea304e320ab2b06c72181070454495cd60ec865f788f7a496b1c72c535dffab918312496fbc4fb550f11cd77a3ea13c9773bc6278f6cb6f1a175c1c1ea7bf434fb3d1af3c41a958c3738b4401a6665914ed603f87d8d43af5be9d0f89c69d12dd6aab3121de691b609491c8200e3eb53adec5dd5ae55d02dedaee086d6daca292faf1cb2bcea1811cfdd1edef591a8e936f78258a08267bd8c196e27c8c03e9b7a05f4c56ae9fa5dc7fc25167a741388ae21988328e02205c1c73daac4c2cb47d7756b5b5b8f3d4c18b87660dc82300638ce4d0934ee0ecd2479fbe977096e9204772ec428452738eb55fecf2c720596374e7a32915dce9f6d7b1e87fda89701207949802c9864c704e3b66a9a24733c573752bdc296320899bae3ae7155cc4721a7e04f15e9be0bfb6ea371626f6fde310dbc65f6a267ef313d7b0e9ef5e81a0fc51d235c436f796d6f637eed847986eb703fbcefc1500753cf4ae1af8a6a5676ba8492c66dd3a5a3a00e3d8f1cd3f4f13cb7704765a5456e1592400c6992bbb861bb9eaa71ee38e94af7071b753aaf891e31bab4f005c6929ae695737d7577f67ba8ec25c3c516092bb436e1ca6d390461c83d78f05af6db4f124baf6ab67e1991ed64b29192d922fdc9da015c164ce242bb01c3e7a1e9935e49e21b58acbc4baada5bc622860bc9a28d01276aab90064924e00ee4d5a77224acccda28a2992145145006ae87e25d5fc3924cfa55df91e7a85955a3591580e9957046473ce3382474273d15bfc59f17450436971796d79a7c4a116c67b48c43851f2708148da402b8230541ed5c451401d9dc7c46bcb816dff124d1a27b7431a491452ab302003bcf99fbc381d5f71ce4f524d518bc6973116234ad25b775dd6e7ff8aae6a8a561dd9d69f1fdd98562fec6d142a9c8c5a9ff00e2a957c7b30bdfb5be85a534d92787b9441924f08b305039e0015c8d145905d9d4cdf11bc59711c51cbab1758976c60c117ca3d3eed66df78a75bd42481e7d46553048268842042a9264b79815001bf249dff7b9eb59145311b7ff0009978a776eff00849758cfafdba5ff00e2ab128a2800a28a2800a28a2800a28a2800a28a2800a28a2800a28a2800a28a2800a28a2803ffd9),
('3211231', 'agasgsaa', '100', 'aadasda', 'In-Stock', 'REFRESHER', 'AVAILABLE', 0xffd8ffe000104a46494600010101004800480000ffe100c64578696600004d4d002a000000080007013200020000001400000062013e00050000000200000076013f000500000006000000860301000500000001000000b6511000010000000101000000511100040000000100000b12511200040000000100000b1200000000323032333a30323a30372031363a30353a32360000007a26000186a000008084000186a00000fa00000186a0000080e8000186a000007530000186a00000ea60000186a000003a98000186a000001770000186a0000186a00000b18fffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc00011080064006403012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00d041c54a0531054c054142a8a954535454aa29898e0b5205a156a50b408605a9145549f52b2b5bd4b39e758e6788ca0390a360ea771c0fc335cff85fc557bafeb53c125b5a4766236684c5216762a464907a0c1f41c8e3340eccebc0a762940a753421b8a514b4a29809453a8a00e6d2a75151274a996a4648a2a641512d3d6689490d2a023ae5871408b030a067b9007b93c0ac2f1578aed7c3567fbc127daa60cb08f2c3007fbc464719fceb4af2f6cd6cd59ae23399630986dd96de31d3deb03e26cd04fa5c1148aa4892555de3bede0d26ecae694e1cd2b338bb4b5d47e216a16ed7bab5a5a5a8b8711a921a51d58fcbec32012702ba7f0ede786b48d7b508adaf64bdbcfb3bc097f7d7114514631f379654ff001648cf51f873e7d61a7ff6478bb4db5d4a34f25a604f9731c480b63ef7b7d39e87ad7a9ddae93697fe30b4bab58eea07b78a658590150e7774f4e5571ef594aa72ebd0e9853e6baebff04e874ad674fd52f2d4412edb49a6fb3a6f70eece064818ea07af7eb5a9756d25acbb241d7907d4564784be1ec3e1fbed32f2cfce8e4112fdbb7cdb959829e8b8f52475e3ad77d2dbda5ebcb195479a051b8775046456b07739aa249e87254669ac70c47bd377559992668a8b7514018486a75355d3207435329a919329a99d3cab95862da81943b305edc7ea49a814d5e61f245263aa28cfe7fe140157589561d16e48cab88cb2b6782c3e603ebc5723f10c437da658ca6e4a97b94666eb85707ffad5d66b96bf6ff0f6a16dce5e06db8f50323f95798f8a8eff000cdab83926080fea0526ae8d29bd4caf1979779e21b1b5b4701e280b995b382465bb7b2feb5e9fe0282d3568753bed652de496eda38a5899c32e163048c7a65cd7955c022fb4e947568a65fce335d7fc3e2cd0ce8dff003f00fe68b5cb2768ab7f5a9d718b6dea7b95c6af67a7e9d3dd348a5625ce1793e8071ef8ad26b9892299548f3761240ebd2bce2205d367f7a451ff008f0ad417d2beab7f12e02a336187de3f2818cfa71453c437d089e1d2441cb1e39269f3c125b3ec994abe01da7a8cd36395a0759233b5d4e437a53ef2f26beb8334ec19c8032063a575eb738f62b93cd14d3d68aa105bdb46ad70b235bdc4c1fe5649c05f7e2a93dacf13ed6519eb8539a8ed6308c302b556c9ae1d648dfe703a1ef472a06cc79eea0b2744ba9e3819ce144ac1777d33d6b734778afaf22b2b962b14657ee8e486ddd4fd4553d47c38be21beb0d2ae46cfddcb74b29404ab26d0aa323bb3027d96b89d03c45aa97bab72f04babdac851eddc8569155b8d9ea55b3c75c1acaa371d91d3428aa9172bec7a96a5a75a58dc4d199c98ca12a9dc0c7435e19aba897c2708041c427f0db3115b3a878ce5b597505b9b9d46de690314b6b98155c123180e79207fbb9c0fc6b024fdef8484a92318d924c06e4839c939a98c9db529d3507a3b99b78760d2dbd2465fcd48aec7e1e8e671e93aff00e8b5ae2b53e2cac0fa5c0fe55dd7801543ccaa41ff0048c9ff00be16b097c3fd773a23b9e836b1037518c71e766b8cf155e5cb69f7bf6391d679a63828d83cbfad77119f2c79bfdd576fcabc9bc61a8c963a7e236c3b4e00fc39ae569bb289d746c9f33e86d437da968762844924eee3e6918e79fa1acfb9f8a1751c86dfecd03ba9c1723a57391f8dae2e74a6b19140988c197d057285bfd20f7c1ea6a30d869a93751bbfab3aea54834a564d3ee7acdbfc4395e205f4d527d4498cd15c3d86a71c56aa8e4120f75ce28addd4ae9e86cb0b8096bcbf99ed51a8ea6b574e9c075158e25cae4558b2b8fdf05039af58f8e3ad58a56d474ebb82257f2cc914a4e32b1b2e723fe04abf9d7ce7e3bd0d9be226b51c7736f0f9976c635964db92c01fc393debe93b1902c20b71c739af95bc65a8aebfe39d53508e6885b9b96f29b3f7941c03fa5675549ad0e8c2c9296a59cf8db498cdb5ddacf716638f2ef2313c38f62738fc08ad2876b7826e25302c1969004462c17d40cf6e456fe81e27ba5d36d2ced826a1047f35d62419427800648e00150f8c35086eec1fc8b1366a11f29f2fce703e6f94915c70ab55cb9671d3b9e856a14a9af7257f99c66a873a7599f4b815de781f4f9ad7529667555499232083c96008391f9579edf49bb4cb6e7a4ca6bd43c37703cf887b7f4a26da490a2af77fd753b498e346ba61d4427afe35e1bf102ee3b9bff002ade331c6b21f937671c73cfd6bd8b599246f096a22056794db1d8aa3249f6af14d43c3be24ba4370da34b1c2d23329618663f89c9a29526da9f609568c5383ea73df65758d65539f5148aad29c640f563d05755a67827c4d70104ba6cb1c529da825758f79c671c9e38159779e1fd6c498fec9ba0abf77cb8495c7a823afd6b6b4ef668b94e8f2a707eaae58b2bad26ded963974f92e5c7590ca533f80a2a82e9dab20c7f65de0fadbb7f85159ba377d7ef674c7154d23d8162d7ec61325c25a32282492e474fc0d79debde3cd6af2f63934a6bcb1844615e203866c9e7a7d3f2af7d113e3ee9ff00beaa03a6176fbb8fc6bbf90f9ce63c1ed7c7de2f92dfec50dc4d897e460612fbb3c739cfe95bf27c26bcd51d6f9b51b2b179d55dad5616c44c472a307d6bd6ff00b00cab8599e36ea194ff00f5ab42cf49f2dd434cee47f130193fa54cbdd57dca8be676d8f1fb2f8317514ebe6788a358cb03208edd81201ed935d178cbc176cfa7c034b9ade092289c32c9f2ac838e491dfdfdebbed4f475b861fbe9171d769c66b32dfc311426e244d42f629255d9c3875c7bab02292f796c5b7caf73e779746d65a06823b292710cdb19e11bc065fa7b60fe35d8787ffb521be8cdcdacb6e8558ee95080063d6bae9be1831bdb89e0f11de44b3105d16051bb1d3a11f4aaf69f0f3c4164f70d16a5657224e3f7d2cc84afa1c6454ba57dd1a4710d3d1976cfc41245e1dd46eb4f0d73a85b2208a35438392391faf6acfd1b51d5b5bd404f7da5dfa4ec705e480803d81e807d2ba8d0749d7ec2d25865b6d321691f7b4a2679549c75d98049ff00810aea2de3648904a50c807cc6352149f6049fe75a46292b2319cdc9dd90c360a9126f19e3919a999467a5592a1d7150ba151c532510ed5fee8a28a29d87763140a9140cd14551996a3e054d0fdfa28ace5b150dc6dcf7aa6dd28a29c3609ee4352a75a28ab21137f0d37bd1454944c9438f968a2a1ee688ac7ad14515641fffd9),
('adaxcaz', 'cxzxczx', '100', 'cxzzxczadd', 'In-Stock', 'COFFEE', 'AVAILABLE', 0xffd8ffe000104a46494600010101006000600000ffe1007a4578696600004d4d002a00000008000601320002000000140000005603010005000000010000006a03030001000000010000000051100001000000010100000051110004000000010000000051120004000000010000000000000000323032333a30323a30372031353a35303a353400000186a00000b18fffdb004300080606070605080707070909080a0c140d0c0b0b0c1912130f141d1a1f1e1d1a1c1c20242e2720222c231c1c2837292c30313434341f27393d38323c2e333432ffdb0043010909090c0b0c180d0d1832211c213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232ffc00011080064006403012200021101031101ffc4001f0000010501010101010100000000000000000102030405060708090a0bffc400b5100002010303020403050504040000017d01020300041105122131410613516107227114328191a1082342b1c11552d1f02433627282090a161718191a25262728292a3435363738393a434445464748494a535455565758595a636465666768696a737475767778797a838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae1e2e3e4e5e6e7e8e9eaf1f2f3f4f5f6f7f8f9faffc4001f0100030101010101010101010000000000000102030405060708090a0bffc400b51100020102040403040705040400010277000102031104052131061241510761711322328108144291a1b1c109233352f0156272d10a162434e125f11718191a262728292a35363738393a434445464748494a535455565758595a636465666768696a737475767778797a82838485868788898a92939495969798999aa2a3a4a5a6a7a8a9aab2b3b4b5b6b7b8b9bac2c3c4c5c6c7c8c9cad2d3d4d5d6d7d8d9dae2e3e4e5e6e7e8e9eaf2f3f4f5f6f7f8f9faffda000c03010002110311003f00f1ff00ecbb81c6d35a167a3b470b4d3718aed9f4f4ebb45666aac21b171d320d6ee272a93671bf6f786eb3137435dee837ab7b6cbe675c579be9f6e67bc3b890a4d77fa5429691a80c0d4aba2a491b5776d988953dbb570b756ecf7e73ce2bd11219ef60115a4324d237015149e6b4b4cf85975340d7baa5c2daa3296088bb9f1ef9c015339c6fcb7d4d28c1db9ac7988b21b7a569787ed146a6b9e07ad7b05c784b448608ee6e6cd679fe55468c941c0e0b81c1271cf15cfeb3e1f50ada85ac61665e658d46030fef003a63b8fc6b0aafdd691d54d7bc8e73c57a4a35b02a996ea0d7106c76b608af56502f6d556419602b91d5f4f16f72428c57360eadd72337c4d3d798e67ec82a430aa2f157644db55253835dc72958939e94504f3453b08eef50d42d6c62cc8ea7f1ae3352d40ea92948bfd5f7350279b74ffe90c5d49e2b7adb4345b532ac8bc7f08ed44eb28ee453a060c1a53c92a476e8cd29e817a9aed740f055d5dc1f689ef1ca29c3c56ea0b2fb163851fad6f697e059e3b985266fb3432442492e5f0383fc2bef5bfacf860cfa9e9b6715d634c16c64487761014e4938eb93839af32be36aae66968bef67a74b0745db9e5abd7c92ff00337acaeec34bd345969bf27950b7ce473f28f9dbdc9a8352bfbe9ed2dd2ce092e14dbbb1ded92cdd71f966b35f51d3adf48b793cb63212d0cd22f2467a8c7e15a3a45f2cda3ca44a0bc1b7c8933d48071fa706bc6589ad5e6af2d5ad6df7dbd7fae8757b08528df9744fafdc55f0e6a96bac2b58dcb35bdda28cc5263257b30f5abf3c02177478da464e5b67423ffd55917fa5691af2c7a84320b2be6f9bcc8d8a866c77c743ee2b4daf469ba21b6b98ae8b3218cdce77919e339e9debd2a78d5caa32edbff9f6673d4c3ae6e687cd7f5b8971e1fd259ee248666d3a48c80d1cc3080ff87d2b85f16d94966bb5d1598f21d0e5587a835d77896ce6b8f0dc51f9b37971905249581258f18f615cd784afedaea2fec8d603cb1bcdb39eb093f748f404e47d6a6355aad671b3febfab9b2c3f3d07352b9e7ce0edcb0c1acf98f35e95e30d06db4cd724b18936c522078b27b1ea3f3af3cbeb692da768e45e9d0fad7b109a6ecf73ca92b2ba28919a29fb68ad4c8dbf0f69d15d89249988118ce315d46916c25d52c608e2436af73199243d00ce30df5354ad2d3eca6078a22b131d8cb9fbd5b69a4dc2d84af00681a3915d48cf38391f5e715e74a7cd3b9daa3689a7e31b1d42fbc59a75b3dcbadbcf18d8dd9073bff1e3f953b54bc7d3161bb963658639d2d53cbcb08e32080c7d738aec342d534cf1558452cb0a79f0b7ce8df7a193183f81e6b4afb40b5bad324b455da8ebb739ebf5fc6bcdc6e5b52acb9e1ac7b757f33b28e6118c6309ab5b439e7f095adc2b25a5e289582bb2b7d3afe79abc9e1f4874c36b244a9230c3cb01ea7b1c1aa92f85afece4596de7170517611b8865f4c7f9fc2a59f59d4f46815759b559212702507faf4cfe54b0d1a54a6fda52717f36adebfe4155d4ab14a9d452fc19cc6ada0c9a2c62e62b894da97c3819050fa91e9ef5a3a66976d751c3325fcaf22b6ef2dfee37b12391576e3c41a4ea7672c2f2b226c3b96407217d47661eb5c9a437fe1ebc8b6dd5bbe9d727e594be015f507fcfd2b3961e11ac9d37ee3fc0d632a9385a7a4d7e2761ab5e69da8469a4dcce6c5b72b61f9040e983e99c735424f023c7aa41a85a5d44ccce37221e180e47f2cd61fd86eb5f9cc4d37fa16fcef0ca40fa7523f4ad9b07d4fc2e1981ff00894db8dc8657562ca7a927aff855d59a936eb465daeb7fb8708ce9c2d4a49793ff00333fe2179377a8dac5323c571e59557231df8ae0a38ddeedacb518fa8f964f5ae93c69787c43a9c3756c8caa47ca58907681c1c76e49fcab056e3ed2925a5d36e741f2c83a8af4e2e5cbabbf9fe479b657b5ac731796cf6d7524582429e0e3a8a2b6e1bc87cbc4c0b3a9c6ec75a2ba9556b468c7913d53367479641a9a4eff00bd4800731b1e0d7abcd3693af68534d64eab347112d1e7054e33c8af2a88c71db6f84907cb1bc8ed55aeefe7b382dee6d6468e32db656538c83d47d2b829e21c65caf66754e8271ba3afb3324128beb097c999c62418ca49fef0feb5d25978a6556f2ef6068e3230cc9f3afd78e47e55c3e9da92476c15ff008471fed0ad48ae6dee908493a8e47422b5a75ac653a67a20bdb59c29b3bc89e441c7ce1b23dfbd4a6f9645686f2df0a461b7ae55bfa1af3970376460e3a311cfe7515cdccec9e5cb25cbc781d24247e59adbdb2b6a67ec9f43b0ba8b49d191fca430a487e74072b1fbe0f41f4aa3a6a69b697ab145716bfd9d3e03dab057512766c13c67dbf2ae5ae14df47fbd9a4957d59c9fd6abc76915ab6f8d021e85ba5704e33f69eed947a7ebf79dd19a74da95dc8eb3c477916992f93611dbaaa0dc638a3091b1fae724d703a96b575a8cab1dcce821ddff001ef17407dfd4d4f7b7f144ac14ab363b1cfe75cec0fe7ea43728039638ac2bd28735e1a5caa529f2da5d0e96ce5f3e49418f95e8dede95cf4b25b0bf957724473b4e7a9ae874e9835a4be50047ad604ba54ba8ea523b98a3881dc4e79c56b4669c9dd93522d2564529f4db8121f276b27639eb454cf7691b948a4764538040a2babdb5430f6701ba1dff00daac2485db134910fe5d6a68e59d3c2e914e14c9e6e307b8cd73ba3c820bfb49b398a6511103a86ed5d25ccb17d896039dc090323a9cd61888a8caddcd68cb9a269260c6acbd0af18a7062bca9c1a834d626d8452a859107407b55929e9d2b16592a6a57312901c1f7619c5432ea978e9b0cc71ea0019a694f5a8dd78e053527b0b95117db2784feea42b9eb8a866bd9e51f3cacded9a575ef50eda69e8044ec769a2cc0372fcff0e291bee93496455649257cec5ebefed512d648a46925f1b6b778c26c128d917bfa9ae5fc3cf769abca27f37729224dc78c7a0ae9268965b3b7b9031f662caca7ae7b1ac3b6d66d19ee1e56ced3c38e3269c2fcb2e5412dd5d9d9c5f64118cdb8cfd28acfd3e34bab349e79583bf2006c714545d1a1e73a35e182fe347c985d867fd93d88aeb75799a0f2269701a27e4af707bd79f296570c33f29c8af44d2ef23d474b8c334824552acd80707d79af471f1b3533cfc24ae9c4cd93509f4c96d65dcf2ef721988fe1ed5d5585f417f107b77cff00b07a8ae7a7b09229d5e66f3e3c60396cb03f41596b14da73cad67379adcb8b66e0b7bfb5722e592b1d0f9a2ee772ec41c115133560d978aeda488477139b7b85e1a2ba42c9f838e7f3a99b5d04e00b1703badce3f98aa7424b505562cd091aa227dab38eb6ad9cfd86203a992eb3fa01546e7c4d026152e9256cfddb6888cffc09a9aa5217b489ab73325b28f35802dd17b9accb6d56279dc8398a26ce41e2b0e6bebfd4e731c4446641b8063966fab5436ba46a22636ab22c71c87e725c7e5c557b187da62e77d11d54b3cf7b139b33e5c2c3039c124f735cc5a59c361a938bb9cb2a1cb2a9c806bb5f92d2c96d621e62eddbf20dccc71dcf6ae4adfc3ef717924d23960ce596dc1e5b9f5f4a9a524934dd9155136d5b53ae85d8c28520924523208e4628a75925d5adb08cdc6dc9276af007b0a2b974374d9e69923915d27852e1d61b83c37cc3839c7e54515ee633f84cf270dfc44753a55cb6a52dcc132a2450945558c6dc860739f5acbf11451d834c90a2e0720b0e68a2bc65f11e9bf84e76451756d693cc374841e7f1359db44985700862c0fe14515db0ea734886cd51a19666452548c0c702a685124bb3b9002a4e08a28ad24ddd931d91a566ccd692dc6e2240e14638183d6babb1b6482e888c01b232ca768e1bd7a75a28ae6ada1bc3733758bb9edf534823958298b0cdfc4c3dcd4fa6befbb48d914ac402a71c80c39a28a4d2f6571fda24b8bbc4c58c3112dc9241f5c7afb51451589a1fffd9);

-- --------------------------------------------------------

--
-- Table structure for table `settings`
--

CREATE TABLE `settings` (
  `SETTINGS_FORM` varchar(50) NOT NULL,
  `SETTINGS_CATEGORY` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Dumping data for table `settings`
--

INSERT INTO `settings` (`SETTINGS_FORM`, `SETTINGS_CATEGORY`) VALUES
('POScategory', 'COFFEE'),
('POScategory', 'REFRESHER'),
('POScategory', 'ADD ONS');

-- --------------------------------------------------------

--
-- Table structure for table `transactionlogs`
--

CREATE TABLE `transactionlogs` (
  `TRANSACTION_ID` varchar(50) NOT NULL,
  `TRANSACTION_DATE` varchar(50) NOT NULL,
  `TRANSACTION_TIME` varchar(50) NOT NULL,
  `TRANSACTION_PRODUCT_ID` varchar(100) NOT NULL,
  `TRANSACTION_AMOUNT` varchar(50) DEFAULT NULL,
  `TRANSACTION_DISCOUNT` varchar(50) DEFAULT NULL,
  `TRANSACTION_USERNAME` varchar(50) NOT NULL,
  `TRANSACTION_USERTYPE` varchar(50) NOT NULL,
  `TRANSACTION_VOIDED` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`ACCOUNT_USERNAME`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`PRODUCT_ID`);

--
-- Indexes for table `transactionlogs`
--
ALTER TABLE `transactionlogs`
  ADD PRIMARY KEY (`TRANSACTION_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
