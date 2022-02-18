﻿using System.ComponentModel.DataAnnotations;

namespace Application.Models.FoundationModels;

/// <summary>
/// The model for creatin foundation in db
/// </summary>
public class FoundationInsertModel
{
    /// <summary>
    /// Name of the foundation
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Year of the foundation
    /// </summary>
    [Required]
    [Range(1900, 2022)]
    public int YearOfFoundation { get; set; }

    /// <summary>
    /// The address of the foundation
    /// </summary>
    [Required]
    public string Address { get; set; }

    /// <summary>
    /// Email of the foundation
    /// </summary>
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    /// <summary>
    /// Website of the foundation
    /// </summary>
    [Required]
    public string Website { get; set; }

    /// <summary>
    /// IBAN of account where benefactors should donate
    /// </summary>
    [Required]
    public string IBAN { get; set; }

    /// <summary>
    /// Phone of the foundation
    /// </summary>
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
}
