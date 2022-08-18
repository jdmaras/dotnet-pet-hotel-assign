using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        //
        public IEnumerable<PetOwner> GetAll()
        {
            Console.WriteLine("get all owners");
            return _context.PetOwners;
        }

        [HttpPost]
        public IActionResult Post(PetOwner petOwner)
        {
            Console.WriteLine("adding a petowner");
            _context.Add(petOwner);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Post), new { id = petOwner.id }, petOwner);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PetOwner petOwner = _context.PetOwners.SingleOrDefault(petOwner => petOwner.id == id);

            if (petOwner is null)
            {
                return NotFound();
            }
            _context.PetOwners.Remove(petOwner);
            _context.SaveChanges();
            return NoContent();
        }

        // THIS SEARCHING PET AND FIND OWNER ID OF PET DEFINITELY ISN'T RIGHT

        // [HttpGet{"{id}"}]
        // public ActionResult<PetOwner> GetOwnerPet(int id)
        // {
        //     Console.WriteLine("getting one pet");
        //     Pet pet = _context.Pets
        //     .Include(PetOwner => PetOwner.PetOwnerId)
        //     .SingleOrDefault(pet => pet.id == id);

        //     if (pet is null)
        //         {
        //             return NotFound();
        //         }
        //     return pet
        // }

    }
}
