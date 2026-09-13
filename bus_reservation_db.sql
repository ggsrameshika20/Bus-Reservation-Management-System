-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 13, 2026 at 12:43 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bus_reservation_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `buses`
--

CREATE TABLE `buses` (
  `bus_id` varchar(20) NOT NULL,
  `bus_name` varchar(50) NOT NULL,
  `route` varchar(100) NOT NULL,
  `source_city` varchar(50) NOT NULL,
  `destination_city` varchar(50) NOT NULL,
  `departure_time` time NOT NULL,
  `arrival_time` time NOT NULL,
  `seat_count` int(11) NOT NULL,
  `fare` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `buses`
--

INSERT INTO `buses` (`bus_id`, `bus_name`, `route`, `source_city`, `destination_city`, `departure_time`, `arrival_time`, `seat_count`, `fare`) VALUES
('001', 'Yuhasnavi', 'Colombo - kadawatha', 'N/A', 'N/A', '08:30:00', '09:30:00', 56, 500.00),
('002', 'Kawee', 'Colombo - Matara', 'N/A', 'N/A', '00:00:00', '00:00:00', 56, 500.00),
('003', 'Neela', 'Colombo - Galle', 'N/A', 'N/A', '00:00:00', '00:00:00', 57, 400.00),
('004', 'Yugathra', 'Colombo - Jafna', 'N/A', 'N/A', '00:00:00', '00:00:00', 50, 1000.00),
('005', 'Nithu', 'Colombo - Kalutara', 'N/A', 'N/A', '00:00:00', '00:00:00', 50, 300.00),
('006', 'Sindarella', 'Colombo - Kandy', 'N/A', 'N/A', '06:00:00', '10:00:00', 55, 800.00),
('007', 'Pearl', 'Colombo - Gampaha', 'N/A', 'N/A', '07:30:00', '08:00:00', 56, 200.00);

-- --------------------------------------------------------

--
-- Table structure for table `payments`
--

CREATE TABLE `payments` (
  `payment_id` int(11) NOT NULL,
  `reservation_id` int(11) NOT NULL,
  `payment_method` varchar(30) NOT NULL,
  `amount_paid` decimal(10,2) NOT NULL,
  `payment_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `status` varchar(20) DEFAULT 'Paid'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `payments`
--

INSERT INTO `payments` (`payment_id`, `reservation_id`, `payment_method`, `amount_paid`, `payment_date`, `status`) VALUES
(1, 6, 'Card', 0.00, '2026-07-17 02:23:38', 'Refunded'),
(2, 7, 'Card', 0.00, '2026-07-17 02:36:20', 'Paid'),
(3, 9, 'Card', 0.00, '2026-07-18 10:04:31', 'Paid'),
(4, 13, 'Card', 0.00, '2026-07-20 11:53:08', 'Paid'),
(5, 14, 'Card', 500.00, '2026-07-20 12:30:27', 'Refunded'),
(6, 14, 'Card', 500.00, '2026-07-20 12:30:36', 'Paid'),
(7, 15, 'Card', 500.00, '2026-07-20 12:39:11', 'Paid'),
(9, 17, 'Card', 500.00, '2026-07-20 14:29:46', 'Paid'),
(12, 27, 'Card', 1600.00, '2026-07-21 06:32:39', 'Paid'),
(13, 29, 'Card', 1600.00, '2026-07-21 06:43:10', 'Paid'),
(17, 35, 'Cash', 500.00, '2026-07-21 09:50:02', 'Paid'),
(18, 36, 'Card', 500.00, '2026-07-21 15:35:24', 'Paid'),
(19, 37, 'Cash', 500.00, '2026-07-22 03:12:27', 'Paid'),
(20, 39, 'Cash', 1000.00, '2026-07-22 04:03:48', 'Refunded'),
(21, 40, 'Cash', 500.00, '2026-07-22 04:31:20', 'Refunded'),
(22, 41, 'Cash', 500.00, '2026-07-23 08:56:20', 'Paid'),
(23, 42, 'Cash', 800.00, '2026-07-23 09:11:13', 'Refunded'),
(24, 44, 'Cash', 400.00, '2026-07-24 10:40:15', 'Refunded'),
(25, 45, 'Card', 200.00, '2026-07-24 11:05:51', 'Refunded'),
(26, 48, 'Card', 1500.00, '2026-07-25 10:34:20', 'Refunded'),
(31, 60, 'Cash', 1000.00, '2026-07-27 05:21:34', 'Refunded'),
(32, 61, 'Cash', 500.00, '2026-07-27 09:02:45', 'Paid'),
(33, 62, 'Card', 500.00, '2026-07-27 09:05:08', 'Refunded'),
(35, 66, 'Cash', 800.00, '2026-09-12 07:29:50', 'Paid'),
(36, 68, 'Cash', 600.00, '2026-09-12 07:40:11', 'Paid'),
(37, 70, 'Cash', 2000.00, '2026-09-12 08:28:27', 'Paid'),
(38, 72, 'Cash', 2000.00, '2026-09-12 10:52:46', 'Paid'),
(39, 74, 'Cash', 2000.00, '2026-09-12 10:56:01', 'Paid');

-- --------------------------------------------------------

--
-- Table structure for table `reservations`
--

CREATE TABLE `reservations` (
  `reservation_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `bus_id` varchar(20) NOT NULL,
  `travel_date` date NOT NULL,
  `seat_no` varchar(5) NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  `status` varchar(20) DEFAULT 'Pending',
  `booking_date` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `reservations`
--

INSERT INTO `reservations` (`reservation_id`, `user_id`, `bus_id`, `travel_date`, `seat_no`, `amount`, `status`, `booking_date`) VALUES
(2, 1, '001', '2026-07-15', '3B', 0.00, 'Cancelled', '2026-07-15 09:57:07'),
(3, 1, '001', '2026-07-15', '3A', 900.00, 'Confirmed', '2026-07-15 10:58:50'),
(4, 1, '001', '2026-07-17', '3C', 500.00, 'Cancelled', '2026-07-17 01:42:04'),
(5, 1, '001', '2026-07-17', '3B', 0.00, 'Confirmed', '2026-07-17 02:03:41'),
(6, 1, '001', '2026-07-17', '3A', 0.00, 'Refunded', '2026-07-17 02:22:50'),
(7, 1, '002', '2026-07-17', '3C', 500.00, 'Confirmed', '2026-07-17 02:35:33'),
(8, 1, '003', '2026-07-18', '3C', 900.00, 'Cancelled', '2026-07-18 10:03:58'),
(9, 1, '003', '2026-07-18', '3B', 900.00, 'Confirmed', '2026-07-18 10:03:58'),
(10, 1, '001', '2026-07-20', '3B', 500.00, 'Confirmed', '2026-07-20 11:09:01'),
(11, 1, '001', '2026-07-20', '3D', 500.00, 'Confirmed', '2026-07-20 11:52:05'),
(12, 1, '001', '2026-07-20', '4D', 500.00, 'Confirmed', '2026-07-20 11:52:05'),
(13, 1, '001', '2026-07-20', '5A', 500.00, 'Confirmed', '2026-07-20 11:52:05'),
(14, 1, '001', '2026-07-20', '2D', 500.00, 'Refunded', '2026-07-20 12:29:46'),
(15, 1, '001', '2026-07-20', '5B', 500.00, 'Cancelled', '2026-07-20 12:38:46'),
(17, 1, '001', '2026-07-20', '14D', 500.00, 'Confirmed', '2026-07-20 14:29:09'),
(24, 1, '001', '2026-07-21', '1C', 500.00, 'Confirmed', '2026-07-21 06:12:19'),
(26, 1, '006', '2026-07-21', '4A', 800.00, 'Cancelled', '2026-07-21 06:31:31'),
(27, 1, '006', '2026-07-21', '7C', 800.00, 'Confirmed', '2026-07-21 06:31:31'),
(28, 1, '006', '2026-07-21', '1D', 800.00, 'Confirmed', '2026-07-21 06:42:34'),
(29, 1, '006', '2026-07-21', '3A', 800.00, 'Confirmed', '2026-07-21 06:42:34'),
(30, 1, '001', '2026-07-21', '1A', 500.00, 'Confirmed', '2026-07-21 08:50:55'),
(35, 1, '001', '2026-07-21', '4D', 500.00, 'Confirmed', '2026-07-21 09:49:51'),
(36, 1, '001', '2026-07-21', '4A', 500.00, 'Confirmed', '2026-07-21 15:34:45'),
(37, 1, '001', '2026-07-22', '1A', 500.00, 'Confirmed', '2026-07-22 03:12:20'),
(38, 1, '001', '2026-07-22', '2C', 500.00, 'Confirmed', '2026-07-22 04:03:38'),
(39, 1, '001', '2026-07-22', '2D', 500.00, 'Refunded', '2026-07-22 04:03:38'),
(40, 14, '001', '2026-07-22', '5A', 500.00, 'Confirmed', '2026-07-22 04:31:14'),
(41, 14, '001', '2026-07-23', '4A', 500.00, 'Confirmed', '2026-07-23 08:56:13'),
(42, 14, '006', '2026-07-23', '3D', 800.00, 'Refunded', '2026-07-23 09:11:04'),
(44, 17, '007', '2026-07-24', '4A', 200.00, 'Refunded', '2026-07-24 10:39:56'),
(45, 17, '007', '2026-07-24', '2D', 200.00, 'Refunded', '2026-07-24 11:05:12'),
(46, 20, '001', '2026-07-25', '2C', 500.00, 'Confirmed', '2026-07-25 10:33:50'),
(47, 20, '001', '2026-07-25', '4A', 500.00, 'Confirmed', '2026-07-25 10:33:50'),
(48, 20, '001', '2026-07-25', '5A', 500.00, 'Refunded', '2026-07-25 10:33:50'),
(49, 20, '001', '2026-07-25', '6C', 500.00, 'Confirmed', '2026-07-25 10:35:49'),
(50, 20, '001', '2026-07-25', '8A', 500.00, 'Confirmed', '2026-07-25 10:35:49'),
(51, 20, '001', '2026-07-25', '7D', 500.00, 'Confirmed', '2026-07-25 10:35:49'),
(52, 20, '007', '2026-07-25', '3D', 200.00, 'Confirmed', '2026-07-25 11:01:29'),
(55, 14, '007', '2026-07-26', '11C', 200.00, 'Confirmed', '2026-07-26 09:27:34'),
(57, 24, '007', '2026-07-27', '3C', 200.00, 'Cancelled', '2026-07-27 04:26:14'),
(59, 25, '001', '2026-07-27', '2C', 500.00, 'Confirmed', '2026-07-27 05:21:07'),
(60, 25, '001', '2026-07-27', '4A', 500.00, 'Refunded', '2026-07-27 05:21:07'),
(61, 27, '001', '2026-07-27', '5A', 500.00, 'Confirmed', '2026-07-27 09:02:39'),
(62, 27, '001', '2026-07-27', '7D', 500.00, 'Refunded', '2026-07-27 09:04:40'),
(63, 29, '001', '2026-07-27', '7C', 500.00, 'Confirmed', '2026-07-27 10:06:39'),
(65, 5, '003', '2026-09-12', '2C', 400.00, 'Confirmed', '2026-09-12 07:29:40'),
(66, 5, '003', '2026-09-12', '4A', 400.00, 'Confirmed', '2026-09-12 07:29:40'),
(68, 31, '005', '2026-09-12', '4A', 300.00, 'Confirmed', '2026-09-12 07:40:04'),
(70, 32, '004', '2026-09-12', '5A', 1000.00, 'Confirmed', '2026-09-12 08:28:20'),
(71, 33, '004', '2026-09-12', '3C', 1000.00, 'Confirmed', '2026-09-12 10:52:39'),
(72, 33, '004', '2026-09-12', '4A', 1000.00, 'Confirmed', '2026-09-12 10:52:39'),
(74, 34, '004', '2026-09-12', '6D', 1000.00, 'Confirmed', '2026-09-12 10:55:55'),
(75, 36, '004', '2026-09-12', '8D', 1000.00, 'Confirmed', '2026-09-12 15:02:09');

-- --------------------------------------------------------

--
-- Table structure for table `seat_availability`
--

CREATE TABLE `seat_availability` (
  `availability_id` int(11) NOT NULL,
  `bus_id` varchar(20) NOT NULL,
  `travel_date` date NOT NULL,
  `seat_no` varchar(5) NOT NULL,
  `is_booked` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `seat_availability`
--

INSERT INTO `seat_availability` (`availability_id`, `bus_id`, `travel_date`, `seat_no`, `is_booked`) VALUES
(1, '001', '2026-07-15', '3C', 1),
(2, '001', '2026-07-15', '3B', 0),
(3, '001', '2026-07-15', '3A', 1),
(4, '001', '2026-07-17', '3C', 0),
(5, '001', '2026-07-17', '3B', 1),
(6, '001', '2026-07-17', '3A', 1),
(7, '002', '2026-07-17', '3C', 1),
(8, '003', '2026-07-18', '3C', 0),
(9, '003', '2026-07-18', '3B', 1),
(10, '001', '2026-07-20', '3B', 1),
(11, '001', '2026-07-20', '3D', 1),
(12, '001', '2026-07-20', '4D', 1),
(13, '001', '2026-07-20', '5A', 1),
(14, '001', '2026-07-20', '2D', 1),
(15, '001', '2026-07-20', '5B', 0),
(16, '001', '2026-07-20', '2C', 1),
(17, '001', '2026-07-20', '14D', 1),
(18, '001', '2026-07-20', '6C', 1),
(19, '001', '2026-07-20', '8D', 1),
(20, '001', '2026-07-20', '12D', 1),
(21, '001', '2026-07-20', '6D', 1),
(22, '001', '2026-07-20', '11D', 1),
(23, '001', '2026-07-20', '5C', 1),
(24, '001', '2026-07-21', '1C', 1),
(25, '001', '2026-07-21', '1D', 1),
(26, '006', '2026-07-21', '4A', 0),
(27, '006', '2026-07-21', '7C', 1),
(28, '006', '2026-07-21', '1D', 1),
(29, '006', '2026-07-21', '3A', 1),
(30, '001', '2026-07-21', '1A', 1),
(31, '001', '2026-07-21', '1B', 0),
(32, '001', '2026-07-21', '2B', 0),
(33, '001', '2026-07-21', '2C', 0),
(34, '001', '2026-07-21', '7D', 1),
(35, '001', '2026-07-21', '4D', 1),
(36, '001', '2026-07-21', '4A', 1),
(37, '001', '2026-07-22', '1A', 1),
(38, '001', '2026-07-22', '2C', 1),
(39, '001', '2026-07-22', '2D', 1),
(40, '001', '2026-07-22', '5A', 1),
(41, '001', '2026-07-23', '4A', 1),
(42, '006', '2026-07-23', '3D', 1),
(43, '007', '2026-07-24', '5A', 0),
(44, '007', '2026-07-24', '4A', 0),
(45, '007', '2026-07-24', '2D', 1),
(46, '001', '2026-07-25', '2C', 1),
(47, '001', '2026-07-25', '4A', 1),
(48, '001', '2026-07-25', '5A', 1),
(49, '001', '2026-07-25', '6C', 1),
(50, '001', '2026-07-25', '8A', 1),
(51, '001', '2026-07-25', '7D', 1),
(52, '007', '2026-07-25', '3D', 1),
(53, '007', '2026-07-25', '2D', 0),
(54, '007', '2026-07-25', '6B', 0),
(55, '007', '2026-07-26', '11C', 1),
(56, '007', '2026-07-26', '9A', 0),
(57, '007', '2026-07-27', '3C', 0),
(58, '007', '2026-07-27', '4A', 0),
(59, '001', '2026-07-27', '2C', 1),
(60, '001', '2026-07-27', '4A', 1),
(61, '001', '2026-07-27', '5A', 1),
(62, '001', '2026-07-27', '7D', 1),
(63, '001', '2026-07-27', '7C', 1),
(64, '001', '2026-07-27', '7B', 0),
(65, '003', '2026-09-12', '2C', 1),
(66, '003', '2026-09-12', '4A', 1),
(67, '005', '2026-09-12', '3C', 0),
(68, '005', '2026-09-12', '4A', 1),
(69, '004', '2026-09-12', '4D', 0),
(70, '004', '2026-09-12', '5A', 1),
(71, '004', '2026-09-12', '3C', 1),
(72, '004', '2026-09-12', '4A', 1),
(73, '004', '2026-09-12', '6C', 0),
(74, '004', '2026-09-12', '6D', 1),
(75, '004', '2026-09-12', '8D', 1),
(76, '004', '2026-09-12', '7C', 0);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `full_name` varchar(100) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(100) NOT NULL,
  `phone` varchar(15) NOT NULL,
  `address` varchar(255) DEFAULT NULL,
  `nic` varchar(20) DEFAULT NULL,
  `role` varchar(20) NOT NULL,
  `status` varchar(20) DEFAULT 'Active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`user_id`, `full_name`, `username`, `password`, `email`, `phone`, `address`, `nic`, `role`, `status`) VALUES
(1, 'System Admin', 'admin', '1234', 'admin@bus.com', '0712345678', NULL, NULL, 'Admin', 'Active'),
(5, 'Full Name', 'nimal', '1234', 'nimalperera@gmail.com', '0701234598', NULL, NULL, 'Passengers', 'Active'),
(6, 'Full Name', 'amal', 'amal', 'amalperera@gmail.com', '0701234567', NULL, NULL, 'Passengers', 'Active'),
(7, 'Full Name', 'senarathna', 'Tharu@21', 'tharushi@21gmail.com', '0713633535', NULL, NULL, 'Passengers', 'Active'),
(8, 'Full Name', 'Tharushi', 'ravishani@21', 'tharushisenarathna@21gmail.com', '0713633535', NULL, NULL, 'Passengers', 'Active'),
(9, 'Full Name', 'sanduni', '12345', 'sandunirameshika0@gamil.com', '0740405981', NULL, NULL, 'Passengers', 'Active'),
(10, 'Full Name', 'Chethana', 'che@2002', 'Chethanaishani91@gmail.com', '0713720532', NULL, NULL, 'Passengers', 'Active'),
(11, 'Full Name', 'Heshani', 'Heshi1013@', 'heshaninawodya.003@gmail.com', '0754595934', NULL, NULL, 'Passengers', 'Active'),
(12, 'Full Name', 'saku', '9876', 'sakuni@gmail.com', '0789654123', NULL, NULL, 'Passengers', 'Active'),
(13, 'Full Name', 'ravishani', '12345', 'tharushisenarathna@21gmail.com', '0713633535', NULL, NULL, 'Passengers', 'Active'),
(14, 'Saman Kumara', 'saman', '123456', 'samankumara@gmail.com', '0758963215', 'Galle 01, malwaththa Matara', '198752638974', 'Passengers', 'Active'),
(15, 'Nileka Perera', 'nileka', '1234', 'nilekalperera@gmail.com', '0741258963', NULL, NULL, 'Passengers', 'Active'),
(16, 'Chamara Nuwan', 'chamara', '0000', 'chamara@gmail.com', '0147852369', NULL, NULL, 'Passengers', 'Active'),
(17, 'aaa', 'aaa', '2222', 'aaa@gmail.com', '0741258963', 'ghjkh', '12345698789', 'Passengers', 'Active'),
(18, 'fatima', 'fati', '', 'fati@gmail.com', '0123456987\\', NULL, NULL, 'User', 'Active'),
(19, 'aaa', '222', '2222', 'rashmi@gmail.com', '080384050', NULL, NULL, 'Passengers', 'Active'),
(20, 'nawodya', 'nawodya', 'nawodya', 'nawo@gmail.com', '0754595934', 'cvsbjhxj', '1233456987', 'Passengers', 'Active'),
(21, 'heshani', 'heshii', '1234', 'heshi@gmail.com', '077777777', NULL, NULL, 'Passengers', 'Active'),
(22, 'heshi', 'heshi', '1234', 'hh@gmail.com', '02222222', 'fdshggfh', '12233564889', 'Passengers', 'Active'),
(23, 'Lala', 'lala', '', 'lala@gamil.com', '013654789', NULL, NULL, 'User', 'Active'),
(24, 'shehani', 'shehani', '2222', 'she@gmail.com', '076666666', 'aghngdkjc', '011236489554', 'Passengers', 'Active'),
(25, 'hashini', 'hashini', '1234', 'hashi@gmail.com', '078999999', 'vkjk,m,b', '1236644789631', 'Passengers', 'Active'),
(27, 'hanji', 'hanji', '1111', 'heshi@gmail.com', '075869123', NULL, NULL, 'Passengers', 'Active'),
(29, 'piumi', 'piumi', '1234', 'piumi@gmail.com', '05555555', 'ghvjbkmnkj', '7894561236547', 'Passengers', 'Active'),
(31, 'nayomi anurada', 'nayomi', '0011', 'nayo@gmail.com', '0741258963', '', '', 'Passengers', 'Active'),
(32, 'Ayomi perera', 'ayomi', '0022', 'ayo@gmail.com', '0741258963', NULL, NULL, 'Passengers', 'Active'),
(33, 'Parami Perera', 'para', '1234', 'para@gmail.com', '0741258963', NULL, NULL, 'Passengers', 'Active'),
(34, 'Nehara Perera', 'neha', '0011', 'neha@gmail.com', '0741258963', NULL, NULL, 'Passengers', 'Active'),
(35, 'Niluka perera', 'niluka', '9988', 'niluka@gmail.com', '0741258963', NULL, NULL, 'Passengers', 'Active'),
(36, 'Pahasara Kariyawasam', 'paha', '1234', 'paha@gmail.com', '0741396852', NULL, NULL, 'Passengers', 'Active');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `buses`
--
ALTER TABLE `buses`
  ADD PRIMARY KEY (`bus_id`);

--
-- Indexes for table `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`payment_id`),
  ADD KEY `reservation_id` (`reservation_id`);

--
-- Indexes for table `reservations`
--
ALTER TABLE `reservations`
  ADD PRIMARY KEY (`reservation_id`),
  ADD KEY `user_id` (`user_id`),
  ADD KEY `bus_id` (`bus_id`);

--
-- Indexes for table `seat_availability`
--
ALTER TABLE `seat_availability`
  ADD PRIMARY KEY (`availability_id`),
  ADD KEY `bus_id` (`bus_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `payments`
--
ALTER TABLE `payments`
  MODIFY `payment_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `reservations`
--
ALTER TABLE `reservations`
  MODIFY `reservation_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=77;

--
-- AUTO_INCREMENT for table `seat_availability`
--
ALTER TABLE `seat_availability`
  MODIFY `availability_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=77;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `payments`
--
ALTER TABLE `payments`
  ADD CONSTRAINT `payments_ibfk_1` FOREIGN KEY (`reservation_id`) REFERENCES `reservations` (`reservation_id`) ON DELETE CASCADE;

--
-- Constraints for table `reservations`
--
ALTER TABLE `reservations`
  ADD CONSTRAINT `reservations_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`user_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `reservations_ibfk_2` FOREIGN KEY (`bus_id`) REFERENCES `buses` (`bus_id`) ON DELETE CASCADE;

--
-- Constraints for table `seat_availability`
--
ALTER TABLE `seat_availability`
  ADD CONSTRAINT `seat_availability_ibfk_1` FOREIGN KEY (`bus_id`) REFERENCES `buses` (`bus_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
